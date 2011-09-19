using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.presence;
using bnet.protocol.channel;
using d3server.Network;

namespace d3server.Services {
	public class PresenceServiceImpl: PresenceService {
		Client client;
		public PresenceServiceImpl(Client client) {
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
