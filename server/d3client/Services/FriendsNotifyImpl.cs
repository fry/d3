using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.friends;

namespace d3.Client.Services {
	public class FriendsNotifyImpl: FriendsNotify {
		Connection connection;
		public FriendsNotifyImpl(Connection connection) {
			this.connection = connection;
		}

		public override void NotifyFriendAdded(Google.ProtocolBuffers.IRpcController controller, FriendNotification request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void NotifyFriendRemoved(Google.ProtocolBuffers.IRpcController controller, FriendNotification request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void NotifyReceivedInvitationAdded(Google.ProtocolBuffers.IRpcController controller, InvitationAddedNotification request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void NotifyReceivedInvitationRemoved(Google.ProtocolBuffers.IRpcController controller, InvitationRemovedNotification request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void NotifySentInvitationRemoved(Google.ProtocolBuffers.IRpcController controller, InvitationRemovedNotification request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}
	}
}
