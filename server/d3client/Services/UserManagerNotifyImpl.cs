using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.user_manager;

namespace d3.Client.Services {
	public class UserManagerNotifyImpl: UserManagerNotify {
		Connection connection;
		public UserManagerNotifyImpl(Connection connection) {
			this.connection = connection;
		}

		public override void NotifyPlayerBlocked(Google.ProtocolBuffers.IRpcController controller, BlockedPlayerNotification request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void NotifyPlayerBlockRemoved(Google.ProtocolBuffers.IRpcController controller, BlockedPlayerNotification request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}
	}
}
