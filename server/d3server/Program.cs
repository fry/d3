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
using System.Diagnostics;
using d3server.Network;

namespace d3server {
	class Program {
		static void Main(string[] args) {
			Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));

			var server = new Server();
			server.Start();

			Console.ReadLine();
		}
	}
}
