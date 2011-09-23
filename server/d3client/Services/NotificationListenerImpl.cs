using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.notification;

namespace d3.Client.Services {
	public class NotificationListenerImpl: NotificationListener {
		Connection connection;
		public NotificationListenerImpl(Connection connection) {
			this.connection = connection;
		}

		public override void OnNotificationReceived(Google.ProtocolBuffers.IRpcController controller, Notification request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}
	}
}
