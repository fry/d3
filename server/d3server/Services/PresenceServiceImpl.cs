using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.presence;
using bnet.protocol.channel;
using d3.Network;

namespace d3.Services {
	public class PresenceServiceImpl: PresenceService {
		ClientHandler client;
		public PresenceServiceImpl(ClientHandler client) {
			this.client = client;
		}

		public override void Subscribe(Google.ProtocolBuffers.IRpcController controller, SubscribeRequest request, Action<bnet.protocol.NoData> done) {
			done(bnet.protocol.NoData.CreateBuilder().Build());
		}

		public override void Unsubscribe(Google.ProtocolBuffers.IRpcController controller, UnsubscribeRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void Update(Google.ProtocolBuffers.IRpcController controller, UpdateRequest request, Action<bnet.protocol.NoData> done) {
			done(bnet.protocol.NoData.CreateBuilder().Build());
		}

		public override void Query(Google.ProtocolBuffers.IRpcController controller, QueryRequest request, Action<QueryResponse> done) {
			throw new NotImplementedException();
		}
	}
}
