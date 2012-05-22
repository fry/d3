using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.game_master;

namespace d3.Server.Services {
	using Attribute = bnet.protocol.attribute.Attribute;
	using bnet.protocol.attribute;
	using d3.Network;
	using Google.ProtocolBuffers;

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
			FindGameResponse.Builder findGameResponse = FindGameResponse.CreateBuilder();
			findGameResponse.SetRequestId(12526585062881647236);

			done(findGameResponse.Build());

			//client.ListenerId = request.ObjectId;

			GameFoundNotification.Builder gameFoundNotification = GameFoundNotification.CreateBuilder();

			GameHandle.Builder gameHandle = GameHandle.CreateBuilder();
			gameHandle.SetFactoryId(request.FactoryId);
			gameHandle.SetGameId(bnet.protocol.EntityId.CreateBuilder().SetHigh(433661094641971304).SetLow(11017467167309309688).Build());

			ConnectInfo.Builder connectInfo = ConnectInfo.CreateBuilder();
			connectInfo.SetToonId(new bnet.protocol.EntityId.Builder {
				High = 216174302532224051,
				Low = 2
			}.Build());
			connectInfo.SetHost("127.0.0.1");
			connectInfo.SetPort(6665);
			connectInfo.SetToken(ByteString.CopyFrom(new byte[] { 0x07, 0x34, 0x02, 0x60, 0x91, 0x93, 0x76, 0x46, 0x28, 0x84 }));
			connectInfo.AddAttribute(Attribute
										 .CreateBuilder()
										 .SetName("SGameId")
										 .SetValue(Variant
													   .CreateBuilder()
													   .SetIntValue(2014314530)
													   .Build())
										 .Build());

			gameFoundNotification.SetRequestId(12526585062881647236);
			gameFoundNotification.SetGameHandle(gameHandle.Build());
			gameFoundNotification.AddConnectInfo(connectInfo.Build());

			client.GetImportedService<GameFactorySubscriber>().NotifyGameFound(controller, gameFoundNotification.Build(), r => { });
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
