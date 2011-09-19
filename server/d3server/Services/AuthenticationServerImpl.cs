using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.authentication;
using bnet.protocol;
using Google.ProtocolBuffers;
using d3server.Network;

namespace d3server.Services {
	public class AuthenticationServerImpl: AuthenticationServer {
		Client client;
		public AuthenticationServerImpl(Client client) {
			this.client = client;
		}

		public override void Logon(Google.ProtocolBuffers.IRpcController controller, LogonRequest request, Action<LogonResponse> done) {
			/*var client_auth = client.GetImportedService<bnet.protocol.authentication.AuthenticationClient>();
			var mod_load_req = ModuleLoadRequest.CreateBuilder();
			var mod_handle = ContentHandle.CreateBuilder();
			mod_handle.SetRegion(0x00005553);
			mod_handle.SetUsage(0x61757468);
			var password_hash = new byte[] { 0x8f, 0x52, 0x90, 0x6a, 0x2c, 0x85, 0xb4, 0x16, 0xa5, 0x95, 0x70, 0x22, 0x51, 0x57, 0xf, 0x96, 0xd3, 0x52, 0x2f, 0x39, 0x23, 0x76, 0x3, 0x11, 0x5f, 0x2f, 0x1a, 0xb2, 0x49, 0x62, 0x4, 0x3c };
			mod_handle.SetHash(ByteString.CopyFrom(password_hash));
			mod_load_req.SetModuleHandle(mod_handle);

			client_auth.ModuleLoad(null, mod_load_req.Build(), res => {
				Console.WriteLine(res);
			});*/


			var response = LogonResponse.CreateBuilder();
			var account = bnet.protocol.EntityId.CreateBuilder();
			var game_account = bnet.protocol.EntityId.CreateBuilder();

			account.SetHigh(0x100000000000000).SetLow(0);

			game_account.SetHigh(0x200006200004433).SetLow(0);

			response.SetAccount(account).SetGameAccount(game_account);

			done(response.Build());
		}

		public override void ModuleMessage(Google.ProtocolBuffers.IRpcController controller, ModuleMessageRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}
	}
}
