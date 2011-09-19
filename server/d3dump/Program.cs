using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.ProtocolBuffers;
using System.IO;

namespace d3dump {
	class Program {
		static void Main(string[] args) {
			var file = File.OpenRead(args[0]);
			var reader = CodedInputStream.CreateInstance(file);

			var expected_responses = new Dictionary<int, IMessage>();

			while (!reader.IsAtEnd) {
				var service_id = reader.ReadRawByte();
				var method_id = reader.ReadInt32() - 1;
				var request_id = reader.ReadFixedUInt16();
				if (service_id == 0xFE) {
				}
			}
		}
	}
}
