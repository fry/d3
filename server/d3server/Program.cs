using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Google.ProtocolBuffers;
using System.Net.Sockets;
using System.Net;
using Google.ProtocolBuffers.Descriptors;
using System.Threading;
using d3server.Services;

namespace d3server {
	

	class Program {
		static void Main(string[] args) {
			var listener = new TcpListener(IPAddress.Any, 6666);

			var registry = new ServiceRegistry();

			registry.RegisterService("bnet.protocol.connection.ConnectionService", typeof(ConnectionServiceImpl));
			registry.RegisterService("bnet.protocol.channel.Channel", typeof(ChannelImpl));
			registry.RegisterService("bnet.protocol.presence.PresenceService", typeof(PresenceServiceImpl));
			registry.RegisterService("bnet.protocol.authentication.AuthenticationServer", typeof(AuthenticationServerImpl));

			listener.Start();

			var client = new Client(registry);
			client.Start(listener.AcceptTcpClient());

			Console.ReadLine();
		}
	}
}
