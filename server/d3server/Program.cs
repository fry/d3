using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Sockets;
using System.Net;
using System.Threading;
using d3.Server;
using System.Diagnostics;
using d3.Network;

namespace d3 {
	class Program {
		static void Main(string[] args) {
			Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));

			var server = new d3.Server.Server();
			server.Start();

			Console.ReadLine();
		}
	}
}
