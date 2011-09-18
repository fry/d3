using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.game_utilities;

namespace d3server.Services {
	public class GameUtilitiesImpl: GameUtilities {
		Client client;
		public GameUtilitiesImpl(Client client) {
			this.client = client;
		}

		public override void ProcessClientRequest(Google.ProtocolBuffers.IRpcController controller, ClientRequest request, Action<ClientResponse> done) {
			throw new NotImplementedException();
		}

		public override void CreateToon(Google.ProtocolBuffers.IRpcController controller, CreateToonRequest request, Action<CreateToonResponse> done) {
			throw new NotImplementedException();
		}

		public override void DeleteToon(Google.ProtocolBuffers.IRpcController controller, DeleteToonRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void TransferToon(Google.ProtocolBuffers.IRpcController controller, TransferToonRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void SelectToon(Google.ProtocolBuffers.IRpcController controller, SelectToonRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void PresenceChannelCreated(Google.ProtocolBuffers.IRpcController controller, PresenceChannelCreatedRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void GetPlayerVariables(Google.ProtocolBuffers.IRpcController controller, PlayerVariablesRequest request, Action<VariablesResponse> done) {
			throw new NotImplementedException();
		}

		public override void GetGameVariables(Google.ProtocolBuffers.IRpcController controller, GameVariablesRequest request, Action<VariablesResponse> done) {
			throw new NotImplementedException();
		}

		public override void GetLoad(Google.ProtocolBuffers.IRpcController controller, bnet.protocol.server_pool.GetLoadRequest request, Action<bnet.protocol.server_pool.ServerState> done) {
			throw new NotImplementedException();
		}
	}
}
