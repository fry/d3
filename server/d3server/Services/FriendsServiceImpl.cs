using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.friends;
using bnet.protocol.invitation;
using d3server.Network;

namespace d3server.Services {
	public class FriendsServiceImpl: FriendsService {
		Client client;
		public FriendsServiceImpl(Client client) {
			this.client = client;
		}

		public override void SubscribeToFriends(Google.ProtocolBuffers.IRpcController controller, SubscribeToFriendsRequest request, Action<SubscribeToFriendsResponse> done) {
			var response = SubscribeToFriendsResponse.CreateBuilder();
			done(response.Build());
		}

		public override void SendInvitation(Google.ProtocolBuffers.IRpcController controller, bnet.protocol.invitation.SendInvitationRequest request, Action<bnet.protocol.invitation.SendInvitationResponse> done) {
			var response = SendInvitationResponse.CreateBuilder();
			done(response.Build());
		}

		public override void AcceptInvitation(Google.ProtocolBuffers.IRpcController controller, bnet.protocol.invitation.GenericRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void RevokeInvitation(Google.ProtocolBuffers.IRpcController controller, bnet.protocol.invitation.GenericRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void DeclineInvitation(Google.ProtocolBuffers.IRpcController controller, bnet.protocol.invitation.GenericRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void IgnoreInvitation(Google.ProtocolBuffers.IRpcController controller, bnet.protocol.invitation.GenericRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void RemoveFriend(Google.ProtocolBuffers.IRpcController controller, GenericFriendRequest request, Action<GenericFriendResponse> done) {
			throw new NotImplementedException();
		}

		public override void ViewFriends(Google.ProtocolBuffers.IRpcController controller, ViewFriendsRequest request, Action<ViewFriendsResponse> done) {
			throw new NotImplementedException();
		}

		public override void UpdateFriendState(Google.ProtocolBuffers.IRpcController controller, UpdateFriendStateRequest request, Action<UpdateFriendStateResponse> done) {
			throw new NotImplementedException();
		}

		public override void UnsubscribeToFriends(Google.ProtocolBuffers.IRpcController controller, UnsubscribeToFriendsRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}
	}
}
