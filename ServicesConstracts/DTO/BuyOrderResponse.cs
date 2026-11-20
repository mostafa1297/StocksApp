using Entities;

namespace ServicesConstracts.DTO
{
    public class BuyOrderResponse
    {
        public Guid? BuyOrderID { get; set; }
        public string? StockSymbol { get; set; }
        public string? StockName { get; set; }
        public DateTime DateAndTimeOfOrder { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TradeAmount { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            if (obj.GetType() != typeof(BuyOrderResponse))
                return false;

            var buyOrderResponse = (BuyOrderResponse)obj;

            if (buyOrderResponse.BuyOrderID == BuyOrderID && buyOrderResponse.StockSymbol == StockSymbol)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BuyOrderID, StockSymbol);
        }

    }

    public static class BuyOrderExtenyions
    {
        public static BuyOrderResponse ToBuyOrderResponse(this BuyOrder buyOrder)
        {
            return new BuyOrderResponse()
            {
                BuyOrderID = buyOrder.BuyOrderID,
                StockSymbol = buyOrder.StockSymbol,
                StockName = buyOrder.StockName,
                DateAndTimeOfOrder = buyOrder.DateAndTimeOfOrder,
                Quantity = buyOrder.Quantity,
                Price = buyOrder.Price,
                TradeAmount = buyOrder.Price * buyOrder.Quantity
            };

        }
    }

}






