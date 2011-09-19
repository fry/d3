using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.game_master;

namespace d3.Services {
	using Attribute = bnet.protocol.attribute.Attribute;
	using bnet.protocol.attribute;
	using d3.Network;

	public class GameMasterImpl: GameMaster {
		ClientHandler client;
		public GameMasterImpl(ClientHandler client) {
			this.client = client;
		}

		public override void JoinGame(Google.ProtocolBuffers.IRpcController controller, JoinGameRequest request, Action<JoinGameResponse> done) {
			throw new NotImplementedException();
		}

		public override void ListFactories(Google.ProtocolBuffers.IRpcController controller, ListFactoriesRequest request, Action<ListFactoriesResponse> done) {
			var response = ListFactoriesResponse.CreateBuilder();

			var description = GameFactoryDescription.CreateBuilder();
			description.SetId(14249086168335147635);
			description.AddAttribute(Attribute.CreateBuilder().SetName("min_players").SetValue(Variant.CreateBuilder().SetIntValue(2)));
			description.AddAttribute(Attribute.CreateBuilder().SetName("max_players").SetValue(Variant.CreateBuilder().SetIntValue(4)));
			description.AddAttribute(Attribute.CreateBuilder().SetName("num_teams").SetValue(Variant.CreateBuilder().SetIntValue(1)));
			description.AddAttribute(Attribute.CreateBuilder().SetName("version").SetValue(Variant.CreateBuilder().SetStringValue("0.3.0")));

			var stats_bucket = GameStatsBucket.CreateBuilder();
			stats_bucket.SetBucketMin(0)
						.SetBucketMax(4294967296)
						.SetWaitMilliseconds(1354)
						.SetGamesPerHour(0)
						.SetActiveGames(69)
						.SetActivePlayers(75)
						.SetFormingGames(0)
						.SetWaitingPlayers(0);

			description.AddStatsBucket(stats_bucket);
			response.AddDescription(description);
			response.SetTotalResults(1);

			done(response.Build());
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
			var response = GetGameStatsResponse.CreateBuilder();
			var stats_bucket = GameStatsBucket.CreateBuilder();
			stats_bucket.SetBucketMin(0)
						.SetBucketMax(4294967296)
						.SetWaitMilliseconds(1354)
						.SetGamesPerHour(0)
						.SetActiveGames(69)
						.SetActivePlayers(75)
						.SetFormingGames(0)
						.SetWaitingPlayers(0);

			response.AddStatsBucket(stats_bucket);
			done(response.Build());
		}
	}
}
