using Entities;
using ServicesConstracts.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace ServicesConstracts.DTO
{
    public class BuyOrderRequest
    {
        [Required]
        public string? StockSymbol { get; set; }
        [Required]
        public string? StockName { get; set; }
        [MinimumOrderDate("2000-01-01")]
        public DateTime DateAndTimeOfOrder { get; set; }
        [Range(1, 100000)]
        public int Quantity { get; set; }
        [Range(1, 10000)]
        public double Price { get; set; }

        public BuyOrder ToBuyOrder()
        {
            return new BuyOrder()
            {
                StockSymbol = StockSymbol,
                StockName = StockName,
                DateAndTimeOfOrder = DateAndTimeOfOrder,
                Quantity = Quantity,
                Price = Price
            };
        }
    }
}
