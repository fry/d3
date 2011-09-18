using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.user_manager;

namespace d3server.Services {
	public class UserManagerServiceImpl: UserManagerService {
		Client client;
		public UserManagerServiceImpl(Client client) {
			this.client = client;
		}

		public override void SubscribeToUserManager(Google.ProtocolBuffers.IRpcController controller, SubscribeToUserManagerRequest request, Action<SubscribeToUserManagerResponse> done) {
			throw new NotImplementedException();
		}

		public override void ReportPlayer(Google.ProtocolBuffers.IRpcController controller, ReportPlayerRequest request, Action<ReportPlayerResponse> done) {
			throw new NotImplementedException();
		}

		public override void BlockPlayer(Google.ProtocolBuffers.IRpcController controller, BlockPlayerRequest request, Action<BlockPlayerResponse> done) {
			throw new NotImplementedException();
		}

		public override void RemovePlayerBlock(Google.ProtocolBuffers.IRpcController controller, RemovePlayerBlockRequest request, Action<RemovePlayerBlockResponse> done) {
			throw new NotImplementedException();
		}

		public override void AddRecentPlayers(Google.ProtocolBuffers.IRpcController controller, AddRecentPlayersRequest request, Action<AddRecentPlayersResponse> done) {
			throw new NotImplementedException();
		}

		public override void RemoveRecentPlayers(Google.ProtocolBuffers.IRpcController controller, RemoveRecentPlayersRequest request, Action<RemoveRecentPlayersResponse> done) {
			throw new NotImplementedException();
		}
	}
}
