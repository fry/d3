using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Google.ProtocolBuffers;
using System.Net.Sockets;
using System.Net;
using Google.ProtocolBuffers.Descriptors;
using System.Threading;
using d3server.Services;
using System.Diagnostics;
using d3server.Network;

namespace d3server {
	

	class Program {
		static void Main(string[] args) {
			var listener = new TcpListener(IPAddress.Any, 6666);

			Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
			var registry = new ServiceRegistry<Client>();

			// Services the client implements
			registry.RegisterService("bnet.protocol.channel.ChannelSubscriber", typeof(bnet.protocol.channel.ChannelSubscriber));
			registry.RegisterService("bnet.protocol.authentication.AuthenticationClient", typeof(bnet.protocol.authentication.AuthenticationClient));
			registry.RegisterService("bnet.protocol.notification.NotificationListener", typeof(bnet.protocol.notification.NotificationListener));
			registry.RegisterService("bnet.protocol.channel_invitation.ChannelInvitationNotify", typeof(bnet.protocol.channel_invitation.ChannelInvitationNotify));
			registry.RegisterService("bnet.protocol.followers.FollowersNotify", typeof(bnet.protocol.followers.FollowersNotify));
			registry.RegisterService("bnet.protocol.user_manager.UserManagerNotify", typeof(bnet.protocol.user_manager.UserManagerNotify));
			registry.RegisterService("bnet.protocol.friends.FriendsNotify", typeof(bnet.protocol.friends.FriendsNotify));
			registry.RegisterService("bnet.protocol.game_master.GameFactorySubscriber", typeof(bnet.protocol.game_master.GameFactorySubscriber));
			registry.RegisterService("bnet.protocol.exchange.ExchangeNotify", typeof(bnet.protocol.exchange.ExchangeNotify));

			// Services we implement
			registry.RegisterService("bnet.protocol.connection.ConnectionService", typeof(ConnectionServiceImpl));
			registry.RegisterService("bnet.protocol.channel.Channel", typeof(ChannelImpl));
			registry.RegisterService("bnet.protocol.presence.PresenceService", typeof(PresenceServiceImpl));
			registry.RegisterService("bnet.protocol.authentication.AuthenticationServer", typeof(AuthenticationServerImpl));
			registry.RegisterService("bnet.protocol.notification.NotificationService", typeof(NotificationServiceImpl));
			registry.RegisterService("bnet.protocol.channel_invitation.ChannelInvitationService", typeof(ChannelInvitationServiceImpl));
			registry.RegisterService("bnet.protocol.toon.external.ToonServiceExternal", typeof(ToonServiceExternalImpl));
			registry.RegisterService("bnet.protocol.followers.FollowersService", typeof(FollowersServiceImpl));
			registry.RegisterService("bnet.protocol.user_manager.UserManagerService", typeof(UserManagerServiceImpl));
			registry.RegisterService("bnet.protocol.friends.FriendsService", typeof(FriendsServiceImpl));
			registry.RegisterService("bnet.protocol.party.PartyService", typeof(PartyServiceImpl));
			registry.RegisterService("bnet.protocol.chat.ChatService", typeof(ChatServiceImpl));
			registry.RegisterService("bnet.protocol.game_master.GameMaster", typeof(GameMasterImpl));
			registry.RegisterService("bnet.protocol.game_utilities.GameUtilities", typeof(GameUtilitiesImpl));
			registry.RegisterService("bnet.protocol.channel.ChannelOwner", typeof(ChannelOwnerImpl));
			registry.RegisterService("bnet.protocol.storage.StorageService", typeof(StorageServiceImpl));
			registry.RegisterService("bnet.protocol.exchange.ExchangeService", typeof(ExchangeServiceImpl));
			registry.RegisterService("bnet.protocol.search.SearchService", typeof(SearchServiceImpl));

			listener.Start();

			var client = new Client(registry);
			client.Start(listener.AcceptTcpClient());

			Console.ReadLine();
		}
	}
}
