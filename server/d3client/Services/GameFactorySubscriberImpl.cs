using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.game_master;

namespace d3.Client.Services {
	public class GameFactorySubscriberImpl: GameFactorySubscriber {
		Connection connection;
		public GameFactorySubscriberImpl(Connection connection) {
			this.connection = connection;
		}

		public override void NotifyGameFound(Google.ProtocolBuffers.IRpcController controller, GameFoundNotification request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}
	}
}
