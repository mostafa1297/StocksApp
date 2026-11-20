using Entities;
using ServicesConstracts;
using ServicesConstracts.DTO;
using ServicesConstracts.Helpers;

namespace Services
{
    public class StocksService : IStocksService
    {
        private List<SellOrder> _sellOrders;
        private List<BuyOrder> _buyOrders;

        public StocksService()
        {
            _sellOrders = new List<SellOrder>();
            _buyOrders = new List<BuyOrder>();
        }

        public Task<BuyOrderResponse> CreateBuyOrder(BuyOrderRequest? buyOrderRequest)
        {
            if (buyOrderRequest == null)
                throw new ArgumentNullException();

            ValidationsHelper.UseValidations(buyOrderRequest);

            var buyOrder = buyOrderRequest.ToBuyOrder();
            buyOrder.BuyOrderID = Guid.NewGuid();

            _buyOrders.Add(buyOrder);

            return Task.FromResult(buyOrder.ToBuyOrderResponse());
        }

        public Task<SellOrderResponse> CreateSellOrder(SellOrderRequest? sellOrderRequest)
        {
            if (sellOrderRequest == null)
                throw new ArgumentNullException();

            ValidationsHelper.UseValidations(sellOrderRequest);

            var sellOrder = sellOrderRequest.ToSellOrder();
            sellOrder.SellOrderID = Guid.NewGuid();

            _sellOrders.Add(sellOrder);

            return Task.FromResult(sellOrder.ToSellOrderResponse());
        }

        public Task<List<BuyOrderResponse>> GetBuyOrders()
        {
            return Task.FromResult(_buyOrders.Select(buyOrder => buyOrder.ToBuyOrderResponse()).ToList());
        }

        public Task<List<SellOrderResponse>> GetSellOrders()
        {
            return Task.FromResult(_sellOrders.Select(sellOrder => sellOrder.ToSellOrderResponse()).ToList());
        }
    }
}
