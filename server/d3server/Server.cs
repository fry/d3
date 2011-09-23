using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using d3.Network;
using d3.Server.Services;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;

namespace d3.Server {
	public class Server {
		ServiceRegistry<ClientHandler> ImportRegistry = new ServiceRegistry<ClientHandler>();
		ServiceRegistry<ClientHandler> ExportRegistry = new ServiceRegistry<ClientHandler>();
		int port;

		public Server(int port = 6666) {
			this.port = port;

			// Services the client implements
			ImportRegistry.RegisterService("bnet.protocol.channel.ChannelSubscriber", typeof(bnet.protocol.channel.ChannelSubscriber));
			ImportRegistry.RegisterService("bnet.protocol.authentication.AuthenticationClient", typeof(bnet.protocol.authentication.AuthenticationClient));
			ImportRegistry.RegisterService("bnet.protocol.notification.NotificationListener", typeof(bnet.protocol.notification.NotificationListener));
			ImportRegistry.RegisterService("bnet.protocol.channel_invitation.ChannelInvitationNotify", typeof(bnet.protocol.channel_invitation.ChannelInvitationNotify));
			ImportRegistry.RegisterService("bnet.protocol.followers.FollowersNotify", typeof(bnet.protocol.followers.FollowersNotify));
			ImportRegistry.RegisterService("bnet.protocol.user_manager.UserManagerNotify", typeof(bnet.protocol.user_manager.UserManagerNotify));
			ImportRegistry.RegisterService("bnet.protocol.friends.FriendsNotify", typeof(bnet.protocol.friends.FriendsNotify));
			ImportRegistry.RegisterService("bnet.protocol.game_master.GameFactorySubscriber", typeof(bnet.protocol.game_master.GameFactorySubscriber));
			ImportRegistry.RegisterService("bnet.protocol.exchange.ExchangeNotify", typeof(bnet.protocol.exchange.ExchangeNotify));

			// Services we implement
			ExportRegistry.RegisterService("bnet.protocol.connection.ConnectionService", typeof(ConnectionServiceImpl));
			ExportRegistry.RegisterService("bnet.protocol.channel.Channel", typeof(ChannelImpl));
			ExportRegistry.RegisterService("bnet.protocol.presence.PresenceService", typeof(PresenceServiceImpl));
			ExportRegistry.RegisterService("bnet.protocol.authentication.AuthenticationServer", typeof(AuthenticationServerImpl));
			ExportRegistry.RegisterService("bnet.protocol.notification.NotificationService", typeof(NotificationServiceImpl));
			ExportRegistry.RegisterService("bnet.protocol.channel_invitation.ChannelInvitationService", typeof(ChannelInvitationServiceImpl));
			ExportRegistry.RegisterService("bnet.protocol.toon.external.ToonServiceExternal", typeof(ToonServiceExternalImpl));
			ExportRegistry.RegisterService("bnet.protocol.followers.FollowersService", typeof(FollowersServiceImpl));
			ExportRegistry.RegisterService("bnet.protocol.user_manager.UserManagerService", typeof(UserManagerServiceImpl));
			ExportRegistry.RegisterService("bnet.protocol.friends.FriendsService", typeof(FriendsServiceImpl));
			ExportRegistry.RegisterService("bnet.protocol.party.PartyService", typeof(PartyServiceImpl));
			ExportRegistry.RegisterService("bnet.protocol.chat.ChatService", typeof(ChatServiceImpl));
			ExportRegistry.RegisterService("bnet.protocol.game_master.GameMaster", typeof(GameMasterImpl));
			ExportRegistry.RegisterService("bnet.protocol.game_utilities.GameUtilities", typeof(GameUtilitiesImpl));
			ExportRegistry.RegisterService("bnet.protocol.channel.ChannelOwner", typeof(ChannelOwnerImpl));
			ExportRegistry.RegisterService("bnet.protocol.storage.StorageService", typeof(StorageServiceImpl));
			ExportRegistry.RegisterService("bnet.protocol.exchange.ExchangeService", typeof(ExchangeServiceImpl));
			ExportRegistry.RegisterService("bnet.protocol.search.SearchService", typeof(SearchServiceImpl));
		}

		public void Start() {
			var listener = new TcpListener(IPAddress.Any, port);
			listener.Start();

			Debug.WriteLine("Listening on {0}", listener.LocalEndpoint);

			while (true) {
				var socket = listener.AcceptTcpClient();
				Debug.WriteLine("Connection from {0}", socket.Client.RemoteEndPoint);
				var client = new ClientHandler(ImportRegistry, ExportRegistry);
				client.Start(socket);
			}
		}
	}
}
