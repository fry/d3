using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bnet.protocol.exchange;
using d3server.Network;
using bnet.protocol.exchange_object_provider;

namespace d3server.Services {
	public class ExchangeServiceImpl: ExchangeService {
		ClientHandler client;
		public ExchangeServiceImpl(ClientHandler client) {
			this.client = client;
		}

		public override void CreateOrderBook(Google.ProtocolBuffers.IRpcController controller, CreateOrderBookRequest request, Action<CreateOrderBookResponse> done) {
			throw new NotImplementedException();
		}

		public override void PlaceOfferOnOrderBook(Google.ProtocolBuffers.IRpcController controller, PlaceOfferOnOrderBookRequest request, Action<PlaceOfferOnOrderBookResponse> done) {
			throw new NotImplementedException();
		}

		public override void PlaceOfferCreateOrderBookIfNeeded(Google.ProtocolBuffers.IRpcController controller, PlaceOfferCreateOrderBookIfNeededRequest request, Action<PlaceOfferCreateOrderBookIfNeededResponse> done) {
			throw new NotImplementedException();
		}

		public override void PlaceBidOnOrderBook(Google.ProtocolBuffers.IRpcController controller, PlaceBidOnOrderBookRequest request, Action<PlaceBidOnOrderBookResponse> done) {
			throw new NotImplementedException();
		}

		public override void PlaceBidCreateOrderBookIfNeeded(Google.ProtocolBuffers.IRpcController controller, PlaceBidCreateOrderBookIfNeededRequest request, Action<PlaceBidCreateOrderBookIfNeededResponse> done) {
			throw new NotImplementedException();
		}

		public override void QueryOffersByOrderBook(Google.ProtocolBuffers.IRpcController controller, QueryOffersByOrderBookRequest request, Action<QueryOffersByOrderBookResponse> done) {
			throw new NotImplementedException();
		}

		public override void QueryBidsByOrderBook(Google.ProtocolBuffers.IRpcController controller, QueryBidsByOrderBookRequest request, Action<QueryBidsByOrderBookResponse> done) {
			throw new NotImplementedException();
		}

		public override void QueryOffersByAccountForItem(Google.ProtocolBuffers.IRpcController controller, QueryOffersByAccountForItemRequest request, Action<QueryOffersByAccountForItemResponse> done) {
			throw new NotImplementedException();
		}

		public override void QueryBidsByAccountForItem(Google.ProtocolBuffers.IRpcController controller, QueryBidsByAccountForItemRequest request, Action<QueryBidsByAccountForItemResponse> done) {
			throw new NotImplementedException();
		}

		public override void QueryOrderBooksSummary(Google.ProtocolBuffers.IRpcController controller, QueryOrderBooksSummaryRequest request, Action<QueryOrderBooksSummaryResponse> done) {
			throw new NotImplementedException();
		}

		public override void QuerySettlementsByOrderBook(Google.ProtocolBuffers.IRpcController controller, QuerySettlementsByOrderBookRequest request, Action<QuerySettlementsByOrderBookResponse> done) {
			throw new NotImplementedException();
		}

		public override void ReportAuthorize(Google.ProtocolBuffers.IRpcController controller, bnet.protocol.exchange_object_provider.ReportAuthorizeRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void ReportSettle(Google.ProtocolBuffers.IRpcController controller, bnet.protocol.exchange_object_provider.ReportSettleRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void ReportCancel(Google.ProtocolBuffers.IRpcController controller, bnet.protocol.exchange_object_provider.ReportCancelRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void SubscribeOrderBookStatusChange(Google.ProtocolBuffers.IRpcController controller, SubscribeOrderBookStatusChangeRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void UnsubscribeOrderBookStatusChange(Google.ProtocolBuffers.IRpcController controller, UnsubscribeOrderBookStatusChangeRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void SubscribeOrderStatusChange(Google.ProtocolBuffers.IRpcController controller, SubscribeOrderStatusChangeRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void UnsubscribeOrderStatusChange(Google.ProtocolBuffers.IRpcController controller, UnsubscribeOrderStatusChangeRequest request, Action<bnet.protocol.NoData> done) {
			var response = bnet.protocol.NoData.CreateBuilder();
			done(response.Build());
		}

		public override void GetPaymentMethods(Google.ProtocolBuffers.IRpcController controller, bnet.protocol.exchange_object_provider.GetPaymentMethodsRequest request, Action<GetPaymentMethodsResponse> done) {
			//var response = GetPaymentMethodsResponse.CreateBuilder();
		}

		public override void ClaimBidItem(Google.ProtocolBuffers.IRpcController controller, ClaimRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void ClaimBidMoney(Google.ProtocolBuffers.IRpcController controller, ClaimRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void ClaimOfferItem(Google.ProtocolBuffers.IRpcController controller, ClaimRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void ClaimOfferMoney(Google.ProtocolBuffers.IRpcController controller, ClaimRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void CancelBid(Google.ProtocolBuffers.IRpcController controller, CancelRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void CancelOffer(Google.ProtocolBuffers.IRpcController controller, CancelRequest request, Action<bnet.protocol.NoData> done) {
			throw new NotImplementedException();
		}

		public override void GetConfiguration(Google.ProtocolBuffers.IRpcController controller, GetConfigurationRequest request, Action<GetConfigurationResponse> done) {
			throw new NotImplementedException();
		}

		public override void GetBidFeeEstimation(Google.ProtocolBuffers.IRpcController controller, GetBidFeeEstimationRequest request, Action<GetFeeEstimationResponse> done) {
			var response = GetFeeEstimationResponse.CreateBuilder();
			done(response.Build());
		}

		public override void GetOfferFeeEstimation(Google.ProtocolBuffers.IRpcController controller, GetOfferFeeEstimationRequest request, Action<GetFeeEstimationResponse> done) {
			throw new NotImplementedException();
		}
	}
}
