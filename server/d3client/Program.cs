using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using d3.Network;
using d3.Client.Services;
using System.Net.Sockets;
using bnet.protocol.connection;

namespace d3.Client {
	public class Connection: BasicAuroraRPC<Connection> {
		public readonly Client Client;
		public Connection(ServiceRegistry<Connection> import_registry, ServiceRegistry<Connection> export_registry, Client client): base(import_registry, export_registry) {
			Client = client;

			// The server exports ConnectionService on index 0 by default
			ImportService("bnet.protocol.connection.ConnectionService", 0);
			// The client also seems to be exporting a ConnectionService
			ExportService("bnet.protocol.connection.ConnectionService", 0);
		}
	}

	public class Client {
		Connection connection;

		string host;
		int port;

		ConnectionService connectionService;
		public Client(string host, int port) {
			this.host = host;
			this.port = port;

			var export_registry = new ServiceRegistry<Connection>();
			// Services we implement
			export_registry.RegisterService("bnet.protocol.connection.ConnectionService", typeof(ConnectionServiceImpl));
			export_registry.RegisterService("bnet.protocol.channel.ChannelSubscriber", typeof(ChannelSubscriberImpl));
			export_registry.RegisterService("bnet.protocol.authentication.AuthenticationClient", typeof(AuthenticationClientImpl));
			export_registry.RegisterService("bnet.protocol.notification.NotificationListener", typeof(NotificationListenerImpl));
			export_registry.RegisterService("bnet.protocol.channel_invitation.ChannelInvitationNotify", typeof(ChannelInvitationNotifyImpl));
			export_registry.RegisterService("bnet.protocol.followers.FollowersNotify", typeof(FollowersNotifyImpl));
			export_registry.RegisterService("bnet.protocol.user_manager.UserManagerNotify", typeof(UserManagerNotifyImpl));
			export_registry.RegisterService("bnet.protocol.friends.FriendsNotify", typeof(FriendsNotifyImpl));
			export_registry.RegisterService("bnet.protocol.game_master.GameFactorySubscriber", typeof(GameFactorySubscriberImpl));
			export_registry.RegisterService("bnet.protocol.exchange.ExchangeNotify", typeof(ExchangeNotifyImpl));

			var import_registry = new ServiceRegistry<Connection>();
			// Services the server implements
			import_registry.RegisterService("bnet.protocol.connection.ConnectionService", typeof(bnet.protocol.connection.ConnectionService));
			import_registry.RegisterService("bnet.protocol.channel.Channel", typeof(bnet.protocol.channel.Channel));
			import_registry.RegisterService("bnet.protocol.presence.PresenceService", typeof(bnet.protocol.presence.PresenceService));
			import_registry.RegisterService("bnet.protocol.authentication.AuthenticationServer", typeof(bnet.protocol.authentication.AuthenticationServer));
			import_registry.RegisterService("bnet.protocol.notification.NotificationService", typeof(bnet.protocol.notification.NotificationService));
			import_registry.RegisterService("bnet.protocol.channel_invitation.ChannelInvitationService", typeof(bnet.protocol.channel_invitation.ChannelInvitationService));
			import_registry.RegisterService("bnet.protocol.toon.external.ToonServiceExternal", typeof(bnet.protocol.toon.external.ToonServiceExternal));
			import_registry.RegisterService("bnet.protocol.followers.FollowersService", typeof(bnet.protocol.followers.FollowersService));
			import_registry.RegisterService("bnet.protocol.user_manager.UserManagerService", typeof(bnet.protocol.user_manager.UserManagerService));
			import_registry.RegisterService("bnet.protocol.friends.FriendsService", typeof(bnet.protocol.friends.FriendsService));
			import_registry.RegisterService("bnet.protocol.party.PartyService", typeof(bnet.protocol.party.PartyService));
			import_registry.RegisterService("bnet.protocol.chat.ChatService", typeof(bnet.protocol.chat.ChatService));
			import_registry.RegisterService("bnet.protocol.game_master.GameMaster", typeof(bnet.protocol.game_master.GameMaster));
			import_registry.RegisterService("bnet.protocol.game_utilities.GameUtilities", typeof(bnet.protocol.game_utilities.GameUtilities));
			import_registry.RegisterService("bnet.protocol.channel.ChannelOwner", typeof(bnet.protocol.channel.ChannelOwner));
			import_registry.RegisterService("bnet.protocol.storage.StorageService", typeof(bnet.protocol.storage.StorageService));
			import_registry.RegisterService("bnet.protocol.exchange.ExchangeService", typeof(bnet.protocol.exchange.ExchangeService));
			import_registry.RegisterService("bnet.protocol.search.SearchService", typeof(bnet.protocol.search.SearchService));

			connection = new Connection(import_registry, export_registry, this);
		}

		public void Start() {
			Console.WriteLine("Connecting to {0}:{1}", host, port);
			var client = new TcpClient(host, port);
			connection.Start(client);
			Console.WriteLine(".. connected");

			connectionService = connection.GetImportedService<ConnectionService>();

			connectionService.Connect(null, ConnectRequest.CreateBuilder().Build(), OnConnectResponse);
			
		}

		void OnConnectResponse(ConnectResponse response) {
			var bind_args = BindRequest.CreateBuilder();
			var hash_auth = connection.ExportRegistry.GetServiceHash("bnet.protocol.authentication.AuthenticationClient");
			var export_auth_id = connection.ExportService(hash_auth, 2);
			bind_args.AddExportedService(new BoundService.Builder {
				Hash = hash_auth,
				Id = export_auth_id
			});

			var hash_auth_server = connection.ImportRegistry.GetServiceHash("bnet.protocol.authentication.AuthenticationServer");
			bind_args.AddImportedServiceHash(hash_auth_server);

			connectionService.Bind(null, bind_args.Build(), r => {
				connection.ImportService(hash_auth_server, r.ImportedServiceIdList[0]);
			});
		}
	}

	class Program {
		static void Main(string[] args) {
			var client = new Client("12.129.236.246", 1119);
			client.Start();
			Console.ReadLine();
		}
	}
}
