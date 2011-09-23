using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.channel_invitation;

namespace d3.Client.Services {
	public class ChannelInvitationNotifyImpl: ChannelInvitationNotify {
		Connection connection;
		public ChannelInvitationNotifyImpl(Connection connection) {
			this.connection = connection;
		}

		public override void NotifyReceivedInvitationAdded(Google.ProtocolBuffers.IRpcController controller, InvitationAddedNotification request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void NotifyReceivedInvitationRemoved(Google.ProtocolBuffers.IRpcController controller, InvitationRemovedNotification request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void NotifyReceivedSuggestionAdded(Google.ProtocolBuffers.IRpcController controller, SuggestionAddedNotification request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void HasRoomForInvitation(Google.ProtocolBuffers.IRpcController controller, HasRoomForInvitationRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}
	}
}
