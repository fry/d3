using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.authentication;

namespace d3.Client.Services {
	public class AuthenticationClientImpl: AuthenticationClient {
		Connection connection;
		public AuthenticationClientImpl(Connection connection) {
			this.connection = connection;
		}

		public override void ModuleLoad(Google.ProtocolBuffers.IRpcController controller, ModuleLoadRequest request, Action<ModuleLoadResponse> done) {
			throw new NotImplementedException();
		}

		public override void ModuleMessage(Google.ProtocolBuffers.IRpcController controller, ModuleMessageRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}
	}
}
