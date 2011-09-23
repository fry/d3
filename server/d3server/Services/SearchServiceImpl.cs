using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.search;
using d3.Network;

namespace d3.Server.Services {
	public class SearchServiceImpl: SearchService {
		ClientHandler client;
		public SearchServiceImpl(ClientHandler client) {
			this.client = client;
		}

		public override void FindMatches(Google.ProtocolBuffers.IRpcController controller, FindMatchesRequest request, Action<FindMatchesResponse> done) {
			throw new NotImplementedException();
		}

		public override void SetObject(Google.ProtocolBuffers.IRpcController controller, SetObjectRequest request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void RemoveObjects(Google.ProtocolBuffers.IRpcController controller, RemoveObjectsRequest request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}
	}
}
