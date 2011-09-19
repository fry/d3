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

namespace d3server.Network {
	public class Client: BasicAuroraRPC<Client> {
		public Client(ServiceRegistry<Client> registry): base(registry) {
			// ConnectionService is expected to be exported on index 0
			ExportService("bnet.protocol.connection.ConnectionService", 0);
		}
	}
}
