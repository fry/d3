using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.ProtocolBuffers;

namespace d3 {
	static class Util {
		public static uint GetServiceHash(string name) {
			var bytes = Encoding.ASCII.GetBytes(name);
			uint result = 0x811C9DC5;
			for (var i = 0; i < bytes.Length; ++i) {
				result = 0x1000193 * (bytes[i] ^ result);
			}
			return result;

		}
		public static ushort ReadFixedUInt16(this CodedInputStream s) {
			return BitConverter.ToUInt16(s.ReadRawBytes(2), 0);
		}

		public static int ReadInt32(this CodedInputStream s) {
			int val = 0;
			s.ReadInt32(ref val);
			return val;
		}

		public static long ReadInt64(this CodedInputStream s) {
			long val = 0;
			s.ReadInt64(ref val);
			return val;
		}

		public static void WriteFixedUInt16(this CodedOutputStream s, ushort val) {
			var bytes = BitConverter.GetBytes(val);
			s.WriteRawBytes(bytes);
		}

		public static string ToHexString(this byte[] data) {
			var builder = new StringBuilder(data.Length * 3 + data.Length / 16 * Environment.NewLine.Length);

			for(int i = 0; i < data.Length; i ++) {
				builder.Append(data[i].ToString("X2"));
				if (i > 0 && i % 16 == 0)
					builder.AppendLine();
				else
					builder.Append(" ");
			}

			return builder.ToString();
		}
	}
}
