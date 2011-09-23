using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.followers;

namespace d3.Client.Services {
	public class FollowersNotifyImpl: FollowersNotify {
		Connection connection;
		public FollowersNotifyImpl(Connection connection) {
			this.connection = connection;
		}

		public override void NotifyFollowerRemoved(Google.ProtocolBuffers.IRpcController controller, FollowerNotification request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}
	}
}
