using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using d3.Network;
using d3.Services;
using System.Net.Sockets;
using System.Net;

namespace d3 {
	public class Server {
		ServiceRegistry<ClientHandler> registry = new ServiceRegistry<ClientHandler>();

		int port;

		public Server(int port = 6666) {
			this.port = port;

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
		}

		public void Start() {
			var listener = new TcpListener(IPAddress.Any, port);
			listener.Start();

			while (true) {
				var socket = listener.AcceptTcpClient();
				var client = new ClientHandler(registry);
				client.Start(socket);
			}
		}
	}
}
