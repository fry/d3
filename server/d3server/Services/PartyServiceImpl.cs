using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.party;

namespace d3server.Services {
	public class PartyServiceImpl: PartyService {
		Client client;
		public PartyServiceImpl(Client client) {
			this.client = client;
		}

		public override void CreateChannel(Google.ProtocolBuffers.IRpcController controller, bnet.protocol.channel.CreateChannelRequest request, Action<bnet.protocol.channel.CreateChannelResponse> done) {
			throw new NotImplementedException();
		}

		public override void JoinChannel(Google.ProtocolBuffers.IRpcController controller, bnet.protocol.channel.JoinChannelRequest request, Action<bnet.protocol.channel.JoinChannelResponse> done) {
			throw new NotImplementedException();
		}

		public override void GetChannelInfo(Google.ProtocolBuffers.IRpcController controller, bnet.protocol.channel.GetChannelInfoRequest request, Action<bnet.protocol.channel.GetChannelInfoResponse> done) {
			throw new NotImplementedException();
		}
	}
}
