using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.storage;
using D3.Hero;

namespace d3server.Services {
	public class StorageServiceImpl: StorageService {
		Client client;
		public StorageServiceImpl(Client client) {
			this.client = client;
		}

		public override void Execute(Google.ProtocolBuffers.IRpcController controller, ExecuteRequest request, Action<ExecuteResponse> done) {
			var response = ExecuteResponse.CreateBuilder();
			
			foreach (var op in request.OperationsList) {

				var result = OperationResult.CreateBuilder();
				result.SetTableId(op.TableId);

				var data = Cell.CreateBuilder();
				data.SetColumnId(op.ColumnId);
				data.SetRowId(op.RowId);

				result.SetErrorCode(1);

				if (request.QueryName == "GetGameAccountSettings") {
					result.SetErrorCode(4);
				} else if (request.QueryName == "GetHeroDigests") {
					var hero_digest = D3.Hero.Digest.CreateBuilder();
					hero_digest.SetVersion(1);
					hero_digest.SetHeroId(D3.OnlineService.EntityId.CreateBuilder().SetIdHigh(0).SetIdLow(0));
					hero_digest.SetHeroName("poop");
					hero_digest.SetGbidClass(0);
					hero_digest.SetLevel(1);
					hero_digest.SetPlayerFlags(0);
					hero_digest.SetVisualEquipment(VisualEquipment.CreateBuilder());
					//hero_digest.SetQuestHistory(QuestHistoryEntry
					hero_digest.SetLastPlayedAct(0);
					hero_digest.SetHighestUnlockedAct(1);
					hero_digest.SetLastPlayedQuest(0);
					hero_digest.SetLastPlayedQuestStep(0);
					hero_digest.SetLastPlayedDifficulty(0);
					hero_digest.SetTimePlayed(0);
					hero_digest.SetHighestUnlockedDifficulty(0);
					data.SetData(hero_digest.Build().ToByteString());
				} else if (request.QueryName == "LoadAccountDigest") {
					var account_digest = D3.Account.Digest.CreateBuilder();
					account_digest.SetVersion(1);
					
					// no last played hero
					var last_played = D3.OnlineService.EntityId.CreateBuilder();
					last_played.SetIdHigh(0);
					last_played.SetIdLow(0);
					account_digest.SetLastPlayedHeroId(last_played);

					// default banner
					var banner = D3.Account.BannerConfiguration.CreateBuilder();
					banner.SetBannerIndex(0).SetSigilMain(0).SetSigilAccent(0).SetPatternColorIndex(0).SetBackgroundColorIndex(0).SetSigilColorIndex(0)
						.SetPlacementIndex(0).SetPattern(0).SetUseSigilVariant(false);
					account_digest.SetBannerConfiguration(banner);

					// default flags
					account_digest.SetFlags(0);

					data.SetData(account_digest.Build().ToByteString());
				}

				result.AddData(data);

				response.AddResults(result);
			}


			done(response.Build());
		}

		public override void OpenTable(Google.ProtocolBuffers.IRpcController controller, OpenTableRequest request, Action<OpenTableResponse> done) {
			var response = OpenTableResponse.CreateBuilder();
			done(response.Build());
		}

		public override void OpenColumn(Google.ProtocolBuffers.IRpcController controller, OpenColumnRequest request, Action<OpenColumnResponse> done) {
			var response = OpenColumnResponse.CreateBuilder();
			done(response.Build());
		}
	}
}
