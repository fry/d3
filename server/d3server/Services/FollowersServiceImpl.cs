using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.followers;
using d3.Network;

namespace d3.Server.Services {
	public class FollowersServiceImpl: FollowersService {
		ClientHandler client;
		public FollowersServiceImpl(ClientHandler client) {
			this.client = client;
		}

		public override void SubscribeToFollowers(Google.ProtocolBuffers.IRpcController controller, SubscribeToFollowersRequest request, Action<SubscribeToFollowersResponse> done) {
			var response = SubscribeToFollowersResponse.CreateBuilder();

			done(response.Build());
		}

		public override void StartFollowing(Google.ProtocolBuffers.IRpcController controller, StartFollowingRequest request, Action<StartFollowingResponse> done) {
			throw new NotImplementedException();
		}

		public override void StopFollowing(Google.ProtocolBuffers.IRpcController controller, StopFollowingRequest request, Action<StopFollowingResponse> done) {
			throw new NotImplementedException();
		}

		public override void UpdateFollowerState(Google.ProtocolBuffers.IRpcController controller, UpdateFollowerStateRequest request, Action<UpdateFollowerStateResponse> done) {
			throw new NotImplementedException();
		}
	}
}
