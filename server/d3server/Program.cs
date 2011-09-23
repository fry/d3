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
using System.IO;

namespace d3 {
	class Program {
		static void Main(string[] args) {
			Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
			Debug.Listeners.Add(new TextWriterTraceListener(File.OpenWrite("server.log")));
			Debug.AutoFlush = true;

			var server = new d3.Server.Server();
			server.Start();

			Console.ReadLine();
		}
	}
}
