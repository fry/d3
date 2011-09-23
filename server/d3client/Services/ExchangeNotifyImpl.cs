using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.exchange;

namespace d3.Client.Services {
	public class ExchangeNotifyImpl: ExchangeNotify {
		Connection connection;
		public ExchangeNotifyImpl(Connection connection) {
			this.connection = connection;
		}

		public override void NotifyOrderBookStatusChange(Google.ProtocolBuffers.IRpcController controller, OrderBookNotificationRequest request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void NotifyOfferStatusChange(Google.ProtocolBuffers.IRpcController controller, OfferNotificationRequest request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}

		public override void NotifyBidStatusChange(Google.ProtocolBuffers.IRpcController controller, BidNotificationRequest request, Action<bnet.protocol.NO_RESPONSE> done) {
			throw new NotImplementedException();
		}
	}
}
