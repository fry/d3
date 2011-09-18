using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.connection;
using Google.ProtocolBuffers;
using bnet.protocol;

namespace d3server.Services {
	public class ConnectionServiceImpl: ConnectionService {
		Client client;
		public ConnectionServiceImpl(Client client) {
			this.client = client;
		}

		public override void Connect(IRpcController controller, ConnectRequest request, Action<ConnectResponse> done) {
			var response = ConnectResponse.CreateBuilder();
			var server_id = ProcessId.CreateBuilder();
			var client_id = ProcessId.CreateBuilder();

			var epoch = (uint)(DateTime.Now - new DateTime(1970,1,1,0,0,0)).TotalSeconds;
			server_id.SetLabel(0).SetEpoch(epoch);
			response.SetServerId(server_id);
			done(response.Build());
		}

		public override void Bind(IRpcController controller, BindRequest request, Action<BindResponse> done) {
			var response = BindResponse.CreateBuilder();
			foreach (var import in request.ImportedServiceHashList) {
				var index = client.ExportService(import);
				response.AddImportedServiceId(index);
			}

			done(response.Build());
		}

		public override void Echo(IRpcController controller, EchoRequest request, Action<EchoResponse> done) {
			throw new NotImplementedException();
		}

		public override void ForceDisconnect(IRpcController controller, DisconnectNotification request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void Null(IRpcController controller, NullRequest request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void Encrypt(IRpcController controller, EncryptRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void RequestDisconnect(IRpcController controller, DisconnectRequest request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}
	}
}
