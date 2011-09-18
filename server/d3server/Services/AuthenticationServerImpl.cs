using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.authentication;

namespace d3server.Services {
	public class AuthenticationServerImpl: AuthenticationServer {
		Client client;
		public AuthenticationServerImpl(Client client) {
			this.client = client;
		}

		public override void Logon(Google.ProtocolBuffers.IRpcController controller, LogonRequest request, Action<LogonResponse> done) {
			var response = LogonResponse.CreateBuilder();
			var account = bnet.protocol.EntityId.CreateBuilder();
			var game_account = bnet.protocol.EntityId.CreateBuilder();

			account.SetHigh(0).SetLow(0);

			game_account.SetHigh(0).SetLow(0);

			response.SetAccount(account).SetGameAccount(game_account);

			done(response.Build());
		}

		public override void ModuleMessage(Google.ProtocolBuffers.IRpcController controller, ModuleMessageRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}
	}
}
