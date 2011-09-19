using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.party;
using bnet.protocol.channel;
using d3server.Network;
using Google.ProtocolBuffers;

namespace d3server.Services {
	public class PartyServiceImpl: PartyService {
		ClientHandler client;
		public PartyServiceImpl(ClientHandler client) {
			this.client = client;
		}

		public override void CreateChannel(Google.ProtocolBuffers.IRpcController controller, bnet.protocol.channel.CreateChannelRequest request, Action<bnet.protocol.channel.CreateChannelResponse> done) {
			var channel_id = bnet.protocol.EntityId.CreateBuilder().SetLow(11233645142038554527).SetHigh(433661094618860925).Build();
			var response = CreateChannelResponse.CreateBuilder();
			response.SetObjectId(1234);
			response.SetChannelId(channel_id);
			done(response.Build());

			var field1 = bnet.protocol.presence.Field.CreateBuilder()
				.SetKey(bnet.protocol.presence.FieldKey.CreateBuilder().SetProgram(16974).SetGroup(3).SetField(3).SetIndex(0))
				.SetValue(bnet.protocol.attribute.Variant.CreateBuilder().SetBoolValue(true));

			var field2 = bnet.protocol.presence.Field.CreateBuilder()
				.SetKey(bnet.protocol.presence.FieldKey.CreateBuilder().SetProgram(16974).SetGroup(3).SetField(10).SetIndex(0))
				.SetValue(bnet.protocol.attribute.Variant.CreateBuilder().SetIntValue(1315530390868296));

			var field3 = bnet.protocol.presence.Field.CreateBuilder()
				.SetKey(bnet.protocol.presence.FieldKey.CreateBuilder().SetProgram(16974).SetGroup(3).SetField(11).SetIndex(0))
				.SetValue(bnet.protocol.attribute.Variant.CreateBuilder().SetMessageValue(
					ByteString.CopyFrom(new byte[] { 0x9, 0x46, 0xee, 0x00, 0x00, 0x00, 0x00, 0x00, 0x4, 0x11, 0xdd, 0xb4, 0x63, 0xe7, 0x82, 0x44, 0x68, 0x4e })));


			var fieldOperation1 = bnet.protocol.presence.FieldOperation.CreateBuilder().SetField(field1);
			var fieldOperation2 = bnet.protocol.presence.FieldOperation.CreateBuilder().SetField(field2);
			var fieldOperation3 = bnet.protocol.presence.FieldOperation.CreateBuilder().SetField(field3);

			var state = bnet.protocol.presence.ChannelState.CreateBuilder()
				.SetEntityId(channel_id)
				.AddFieldOperation(fieldOperation1)
				.AddFieldOperation(fieldOperation2)
				.AddFieldOperation(fieldOperation3);


			var channelState = bnet.protocol.channel.ChannelState.CreateBuilder().SetExtension(bnet.protocol.presence.ChannelState.Presence, state.Build());
			var notif = bnet.protocol.channel.UpdateChannelStateNotification.CreateBuilder().SetStateChange(channelState).Build();

			var serv = client.GetImportedService<ChannelSubscriber>();
			serv.NotifyUpdateChannelState(null, notif, d => { });
		}

		public override void JoinChannel(Google.ProtocolBuffers.IRpcController controller, bnet.protocol.channel.JoinChannelRequest request, Action<bnet.protocol.channel.JoinChannelResponse> done) {
			throw new NotImplementedException();
		}

		public override void GetChannelInfo(Google.ProtocolBuffers.IRpcController controller, bnet.protocol.channel.GetChannelInfoRequest request, Action<bnet.protocol.channel.GetChannelInfoResponse> done) {
			throw new NotImplementedException();
		}
	}
}
