using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.game_master;

namespace d3server.Services {
	public class GameMasterImpl: GameMaster {
		Client client;
		public GameMasterImpl(Client client) {
			this.client = client;
		}

		public override void JoinGame(Google.ProtocolBuffers.IRpcController controller, JoinGameRequest request, Action<JoinGameResponse> done) {
			throw new NotImplementedException();
		}

		public override void ListFactories(Google.ProtocolBuffers.IRpcController controller, ListFactoriesRequest request, Action<ListFactoriesResponse> done) {
			throw new NotImplementedException();
		}

		public override void FindGame(Google.ProtocolBuffers.IRpcController controller, FindGameRequest request, Action<FindGameResponse> done) {
			throw new NotImplementedException();
		}

		public override void CancelFindGame(Google.ProtocolBuffers.IRpcController controller, CancelFindGameRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void GameEnded(Google.ProtocolBuffers.IRpcController controller, GameEndedNotification request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void PlayerLeft(Google.ProtocolBuffers.IRpcController controller, PlayerLeftNotification request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void RegisterServer(Google.ProtocolBuffers.IRpcController controller, RegisterServerRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void UnregisterServer(Google.ProtocolBuffers.IRpcController controller, UnregisterServerRequest request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void RegisterUtilities(Google.ProtocolBuffers.IRpcController controller, RegisterUtilitiesRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void UnregisterUtilities(Google.ProtocolBuffers.IRpcController controller, UnregisterUtilitiesRequest request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void Subscribe(Google.ProtocolBuffers.IRpcController controller, SubscribeRequest request, Action<SubscribeResponse> done) {
			throw new NotImplementedException();
		}

		public override void Unsubscribe(Google.ProtocolBuffers.IRpcController controller, UnsubscribeRequest request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void ChangeGame(Google.ProtocolBuffers.IRpcController controller, ChangeGameRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void GetFactoryInfo(Google.ProtocolBuffers.IRpcController controller, GetFactoryInfoRequest request, Action<GetFactoryInfoResponse> done) {
			throw new NotImplementedException();
		}

		public override void GetGameStats(Google.ProtocolBuffers.IRpcController controller, GetGameStatsRequest request, Action<GetGameStatsResponse> done) {
			throw new NotImplementedException();
		}
	}
}
