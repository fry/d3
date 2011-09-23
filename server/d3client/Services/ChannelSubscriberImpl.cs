using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.channel;

namespace d3.Client.Services {
	public class ChannelSubscriberImpl: ChannelSubscriber {
		Connection connection;
		public ChannelSubscriberImpl(Connection connection) {
			this.connection = connection;
		}

		public override void NotifyAdd(Google.ProtocolBuffers.IRpcController controller, AddNotification request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void NotifyJoin(Google.ProtocolBuffers.IRpcController controller, JoinNotification request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void NotifyRemove(Google.ProtocolBuffers.IRpcController controller, RemoveNotification request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void NotifyLeave(Google.ProtocolBuffers.IRpcController controller, LeaveNotification request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void NotifySendMessage(Google.ProtocolBuffers.IRpcController controller, SendMessageNotification request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void NotifyUpdateChannelState(Google.ProtocolBuffers.IRpcController controller, UpdateChannelStateNotification request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void NotifyUpdateMemberState(Google.ProtocolBuffers.IRpcController controller, UpdateMemberStateNotification request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}
	}
}
