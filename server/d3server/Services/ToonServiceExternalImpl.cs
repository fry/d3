using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.toon.external;
using bnet.protocol;
using d3.Network;

namespace d3.Services {
	public class ToonServiceExternalImpl: ToonServiceExternal {
		ClientHandler client;
		public ToonServiceExternalImpl(ClientHandler client) {
			this.client = client;
		}

		public override void ToonList(Google.ProtocolBuffers.IRpcController controller, ToonListRequest request, Action<ToonListResponse> done) {
			var response = ToonListResponse.CreateBuilder();
			done(response.Build());
		}

		public override void SelectToon(Google.ProtocolBuffers.IRpcController controller, SelectToonRequest request, Action<SelectToonResponse> done) {
			var response = SelectToonResponse.CreateBuilder();

			done(response.Build());
		}

		public override void CreateToon(Google.ProtocolBuffers.IRpcController controller, CreateToonRequest request, Action<CreateToonResponse> done) {
			foreach (var attr in request.AttributeList) {
				if (attr.Name == "HeroCreateParams") {
					var create_params = D3.OnlineService.HeroCreateParams.ParseFrom(attr.Value.MessageValue);

				}
			}

			var response = CreateToonResponse.CreateBuilder();
			var toon = EntityId.CreateBuilder();
			toon.SetHigh(216174302532224051);
			toon.SetLow(2345959482769161802);
			response.SetToon(toon);
			done(response.Build());
		}

		public override void DeleteToon(Google.ProtocolBuffers.IRpcController controller, DeleteToonRequest request, Action<DeleteToonResponse> done) {
			throw new NotImplementedException();
		}
	}
}
