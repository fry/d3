using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.channel_invitation;
using System.Diagnostics;
using d3.Network;

namespace d3.Services {
	public class ChannelInvitationServiceImpl: ChannelInvitationService {
		ClientHandler client;
		public ChannelInvitationServiceImpl(ClientHandler client) {
			this.client = client;
		}

		public override void Subscribe(Google.ProtocolBuffers.IRpcController controller, SubscribeRequest request, Action<SubscribeResponse> done) {
			Debug.WriteLine("Subscribe request");
			var response = SubscribeResponse.CreateBuilder();

			done(response.Build());
		}

		public override void Unsubscribe(Google.ProtocolBuffers.IRpcController controller, UnsubscribeRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void SendInvitation(Google.ProtocolBuffers.IRpcController controller, bnet.protocol.invitation.SendInvitationRequest request, Action<bnet.protocol.invitation.SendInvitationResponse> done) {
			throw new NotImplementedException();
		}

		public override void AcceptInvitation(Google.ProtocolBuffers.IRpcController controller, AcceptInvitationRequest request, Action<AcceptInvitationResponse> done) {
			throw new NotImplementedException();
		}

		public override void DeclineInvitation(Google.ProtocolBuffers.IRpcController controller, bnet.protocol.invitation.GenericRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void RevokeInvitation(Google.ProtocolBuffers.IRpcController controller, RevokeInvitationRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void SuggestInvitation(Google.ProtocolBuffers.IRpcController controller, SuggestInvitationRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}
	}
}
