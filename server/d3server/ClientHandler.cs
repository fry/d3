using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.ProtocolBuffers;
using System.Net.Sockets;
using System.Threading;
using Google.ProtocolBuffers.Descriptors;
using System.Diagnostics;
using System.IO;
using d3.Network;

namespace d3.Server {
	public class ClientHandler: BasicAuroraRPC<ClientHandler> {
		public ClientHandler(ServiceRegistry<ClientHandler> import_registry, ServiceRegistry<ClientHandler> export_registry): base(import_registry, export_registry) {
			// ConnectionService is expected to be exported on index 0
			ExportService("bnet.protocol.connection.ConnectionService", 0);
		}
	}
}
