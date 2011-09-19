using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.notification;
using d3server.Network;

namespace d3server.Services {
	public class NotificationServiceImpl: NotificationService {
		Client client;
		public NotificationServiceImpl(Client client) {
			this.client = client;
		}

		public override void SendNotification(Google.ProtocolBuffers.IRpcController controller, Notification request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void RegisterClient(Google.ProtocolBuffers.IRpcController controller, RegisterClientRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void UnregisterClient(Google.ProtocolBuffers.IRpcController controller, UnregisterClientRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void FindClient(Google.ProtocolBuffers.IRpcController controller, FindClientRequest request, Action<FindClientResponse> done) {
			throw new NotImplementedException();
		}
	}
}
