using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace d3.Network {
	public class BasicAuroraRPC<T>: IRpcChannel where T: class {
		const int RESPONSE_SERVICE_ID = 0xFE;

		struct ResponseData {
			public IMessage ResponsePrototype;
			public Action<IMessage> Callback;
		}

		class SendQueueEntry {
			public uint ServiceId;
			public uint MethodId;
			public ushort RequestId;
			public uint? ListenerId;
			public IMessage Message;
		}

		// The services the server exports to the client
		Dictionary<uint, IService> exportedServices = new Dictionary<uint, IService>();
		// Counter for ID to use for next exported service
		uint exportCounter = 0;

		// The services the client exports to the server (or the server imports from the client)
		Dictionary<uint, IService> importedServices = new Dictionary<uint, IService>();
		// Maps service name hash to service id
		Dictionary<uint, uint> importedServicesIds = new Dictionary<uint, uint>();
		// Maps service type to service
		Dictionary<Type, IService> importedServicesTypes = new Dictionary<Type, IService>();

		// Callback functions waiting for responses to the specified requestID
		Dictionary<ushort, ResponseData> awaitingResponse = new Dictionary<ushort, ResponseData>();

		ServiceRegistry<T> registry;

		// Counts requests sent from the server side
		ushort requestCounter = 0;

		TcpClient socket;

		Queue<SendQueueEntry> sendQueue = new Queue<SendQueueEntry>();

		public BasicAuroraRPC(ServiceRegistry<T> registry) {
			this.registry = registry;
		}

		/// <summary>
		/// Export a service to the client based on its name
		/// </summary>
		/// <param name="name">the fully qualified name of the service, i.e.: "bnet.protocol.connection.ConnectionService"</param>
		/// <param name="overwriteIndex"></param>
		/// <returns></returns>
		public uint ExportService(string name, uint? overwriteIndex = null) {
			var hash = Util.GetServiceHash(name);
			return ExportService(hash, overwriteIndex);
		}

		/// <summary>
		/// Export a service to the client based on its hash
		/// </summary>
		/// <param name="hash"></param>
		/// <param name="overwriteIndex"></param>
		/// <returns></returns>
		public uint ExportService(uint hash, uint? overwriteIndex = null) {
			// TODO: check if the service is already bound

			// Lookup the service with this hash in the registry
			var service = registry.CreateBoundService(hash, this as T);
			// Determine the index to use
			uint index = exportCounter++;
			// If an overwrite index is specified (required for ConnectionService), correct counter
			if (overwriteIndex.HasValue) {
				index = overwriteIndex.Value;
				exportCounter = index + 1;
			}
			exportedServices.Add(index, service);
			return index;
		}

		public void ImportService(uint hash, uint index) {
			// Create a stub for the imported service with us as the RPC channel
			var type = registry.GetServiceType(hash);
			var service = registry.CreateStub(type, this as T);
			// Store a reference to the service by index, and a reference to the index by hash
			importedServices[index] = service;
			importedServicesIds[hash] = index;
			importedServicesTypes[type] = service;
		}

		/// <summary>
		/// Return a stub to the service exported by the client
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="name"></param>
		/// <returns></returns>
		public T GetImportedService<T>() where T: class, IService {
			IService service;
			if (!importedServicesTypes.TryGetValue(typeof(T), out service))
				return null;

			return service as T;
		}

		public uint GetImportedServiceId(string name) {
			var hash = Util.GetServiceHash(name);
			return importedServicesIds[hash];
		}

		public void CallMethod(MethodDescriptor method, IRpcController controller, IMessage request, IMessage responsePrototype, Action<IMessage> done) {
			var service_id = GetImportedServiceId(method.Service.FullName);
			var request_id = requestCounter++;

			// Register the handler for the response before sending the packet to avoid highly unlikely race-conditions
			lock (awaitingResponse) {
				awaitingResponse[request_id] = new ResponseData {
					ResponsePrototype = responsePrototype,
					Callback = done
				};
			}

			// Enqueue the request packet
			lock (sendQueue) {
				sendQueue.Enqueue(new SendQueueEntry {
					ServiceId = service_id,
					ListenerId = 0, // TODO: determine correct value here
					RequestId = request_id,
					MethodId = (uint)method.Index + 1,
					Message = request
				});

				Monitor.Pulse(sendQueue);
			}
		}

		public void SendResponse(ushort requestId, IMessage message) {
			lock (sendQueue) {
				sendQueue.Enqueue(new SendQueueEntry {
					ServiceId = RESPONSE_SERVICE_ID,
					ListenerId = null,
					RequestId = requestId,
					MethodId = 0, // TODO: Add error code here
					Message = message
				});

				// Notify the waiting write loop
				Monitor.Pulse(sendQueue);
			}
		}

		public void Start(TcpClient socket) {
			this.socket = socket;

			new Thread(new ThreadStart(ReadLoop)).Start();
			new Thread(new ThreadStart(WriteLoop)).Start();
		}

		public void Disconnect(string reason) {
			Debug.WriteLine("Disconnecting client: " + reason);
			socket.Close();
		}

		void ReadLoop() {
			var reader = CodedInputStream.CreateInstance(socket.GetStream());
			while (socket.Connected) {
				try {
					HandlePacket(reader);
				} catch (Exception e) {
					Disconnect(e.Message);
				}
			}
		}

		void WriteLoop() {
			var writer = CodedOutputStream.CreateInstance(socket.GetStream());
			while (socket.Connected) {
				try {
					SendQueueEntry send_data = null;
					lock (sendQueue) {
						// Wait for messages in the send queue
						while (sendQueue.Count == 0)
							Monitor.Wait(sendQueue);

						send_data = sendQueue.Dequeue();
					}

					SendData(writer, send_data);
				} catch (Exception e) {
					Disconnect(e.Message);
				}
			}
		}

		void SendData(CodedOutputStream writer, SendQueueEntry data) {
			// Write to a temp buffer so we can inspect what we send
			var stream = new MemoryStream();
			var temp_writer = CodedOutputStream.CreateInstance(stream);
			temp_writer.WriteRawByte(data.ServiceId);
			temp_writer.WriteUInt32NoTag(data.MethodId);
			temp_writer.WriteFixedUInt16(data.RequestId);
			if (data.ListenerId.HasValue)
				temp_writer.WriteUInt32NoTag(data.ListenerId.Value);

			temp_writer.WriteMessageNoTag(data.Message);
			temp_writer.Flush();

			var buffer = stream.ToArray();
			//Debug.WriteLine("Sending data: ");
			//Debug.WriteLine(buffer.ToHexString());

			writer.WriteRawBytes(buffer);
			writer.Flush();
		}

		void HandlePacket(CodedInputStream reader) {
			var service_id = reader.ReadRawByte();
			var method_id = reader.ReadInt32() - 1;
			var request_id = reader.ReadFixedUInt16();

			Debug.WriteLine("Received packet [service_id: 0x{0:X2}, method_id: {1}, request_id: {2}]", service_id, method_id, request_id);
			// Handle RPC responses
			if (service_id == RESPONSE_SERVICE_ID) {
				Debug.WriteLine("  received response");
				HandleResponse(request_id, reader);
			} else {
				var listener_id = reader.ReadInt64();
				Debug.WriteLine("  listener_id: {0}", listener_id);

				IService service;
				if (!exportedServices.TryGetValue(service_id, out service))
					throw new ArgumentException("No service bound on index " + service_id);

				// Load correct descriptor for the requested method
				var method_descriptor = service.DescriptorForType.Methods[method_id];
				// Create a prototype of the request message
				var message_prototype = service.GetRequestPrototype(method_descriptor);
				// And create a builder for that message
				var builder = message_prototype.WeakCreateBuilderForType();
				// Read the message into the correct builder
				var message = ReadMessage(reader, builder);

				Debug.WriteLine("  passing RPC to {0}::{1}", method_descriptor.Service.Name, method_descriptor.Name);
				Debug.WriteLine(message.ToString());

				// Response callback sends the repsponse
				service.CallMethod(method_descriptor, null, message, m => SendResponse(request_id, m));
			}
		}

		void HandleResponse(ushort requestId, CodedInputStream reader) {
			// Lookup the request id in the dictionary containing pending responses
			ResponseData response_data;
			if (!awaitingResponse.TryGetValue(requestId, out response_data))
				throw new ArgumentException("No pending response with the id " + requestId);

			// Retrieve the correct prototype and create a builder
			var message_builder = response_data.ResponsePrototype.WeakCreateBuilderForType();
			// Read the message into the correct builder
			var message = ReadMessage(reader, message_builder);

			// Invoke the registered callback
			response_data.Callback(message);
		}

		IMessage ReadMessage(CodedInputStream reader, IBuilder builder) {
			reader.ReadMessage(builder, ExtensionRegistry.Empty);
			return builder.WeakBuildPartial();
		}
	}
}
