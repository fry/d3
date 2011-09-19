using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.chat;
using d3server.Network;

namespace d3server.Services {
	public class ChatServiceImpl: ChatService {
		ClientHandler client;
		public ChatServiceImpl(ClientHandler client) {
			this.client = client;
		}

		public override void FindChannel(Google.ProtocolBuffers.IRpcController controller, bnet.protocol.channel.FindChannelRequest request, Action<bnet.protocol.channel.FindChannelResponse> done) {
			throw new NotImplementedException();
		}

		public override void CreateChannel(Google.ProtocolBuffers.IRpcController controller, bnet.protocol.channel.CreateChannelRequest request, Action<bnet.protocol.channel.CreateChannelResponse> done) {
			throw new NotImplementedException();
		}

		public override void JoinChannel(Google.ProtocolBuffers.IRpcController controller, bnet.protocol.channel.JoinChannelRequest request, Action<bnet.protocol.channel.JoinChannelResponse> done) {
			throw new NotImplementedException();
		}
	}
}
