using Entities;

namespace ServicesConstracts.DTO
{
    public class SellOrderResponse
    {
        public Guid? SellOrderID { get; set; }
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

            if (obj.GetType() != typeof(SellOrderResponse))
                return false;

            var sellOrderResponse = (SellOrderResponse)obj;

            if (sellOrderResponse.SellOrderID == SellOrderID && sellOrderResponse.StockSymbol == StockSymbol)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SellOrderID, StockSymbol);
        }
    }
    public static class SellOrderExtenyions
    {
        public static SellOrderResponse ToSellOrderResponse(this SellOrder sellOrder)
        {
            return new SellOrderResponse()
            {
                SellOrderID = sellOrder.SellOrderID,
                StockSymbol = sellOrder.StockSymbol,
                StockName = sellOrder.StockName,
                DateAndTimeOfOrder = sellOrder.DateAndTimeOfOrder,
                Quantity = sellOrder.Quantity,
                Price = sellOrder.Price,
                TradeAmount = sellOrder.Price * sellOrder.Quantity
            };

        }
    }
}
