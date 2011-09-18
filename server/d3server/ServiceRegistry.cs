using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.ProtocolBuffers;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace d3server {
	public class ServiceRegistry {
		public static uint GetServiceHash(string name) {
			var bytes = Encoding.ASCII.GetBytes(name);
			uint result = 0x811C9DC5;
			for (var i = 0; i < bytes.Length; ++i) {
				result = 0x1000193 * (bytes[i] ^ result);
			}
			return result;
		}

		ConcurrentDictionary<uint, Type> services = new ConcurrentDictionary<uint, Type>();

		public void RegisterService(string name, Type implementation) {
			Debug.Assert(implementation.GetInterfaces().Contains(typeof(IService)));

			var hash = GetServiceHash(name);

			Debug.Assert(services.TryAdd(hash, implementation), String.Format("Service already registered: {0}/{1:X8}", name, hash));
		}

		public Type GetServiceType(uint hash) {
			Type service_type;
			if (!services.TryGetValue(hash, out service_type))
				throw new ArgumentException("No such service registered: 0x" + hash.ToString("X8"));
			return service_type;
		}

		public IService CreateBoundService(uint hash, Client client) {
			var constructor = GetServiceType(hash).GetConstructor(new Type[] { typeof(Client) });

			return constructor.Invoke(new object[] { client }) as IService;
		}

		public IService CreateStub(uint hash, Client client) {
			var stub = GetServiceType(hash).GetMethod("CreateStub").Invoke(null, new object[] { client });
			return stub as IService;
		}
	}
}
