using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.connection;

namespace d3.Client.Services {
	public class ConnectionServiceImpl: ConnectionService {
		Connection connection;
		public ConnectionServiceImpl(Connection connection) {
			this.connection = connection;
		}

		public override void Connect(Google.ProtocolBuffers.IRpcController controller, ConnectRequest request, Action<ConnectResponse> done) {
			throw new NotImplementedException();
		}

		public override void Bind(Google.ProtocolBuffers.IRpcController controller, BindRequest request, Action<BindResponse> done) {
			throw new NotImplementedException();
		}

		public override void Echo(Google.ProtocolBuffers.IRpcController controller, EchoRequest request, Action<EchoResponse> done) {
			throw new NotImplementedException();
		}

		public override void ForceDisconnect(Google.ProtocolBuffers.IRpcController controller, DisconnectNotification request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void Null(Google.ProtocolBuffers.IRpcController controller, NullRequest request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void Encrypt(Google.ProtocolBuffers.IRpcController controller, EncryptRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void RequestDisconnect(Google.ProtocolBuffers.IRpcController controller, DisconnectRequest request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}
	}
}
