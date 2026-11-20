using Services;
using ServicesConstracts;
using ServicesConstracts.DTO;
using System.Security.Cryptography.X509Certificates;

namespace Tests
{
    public class StocksServiceTest
    {
        private readonly IStocksService _stocksService;

        public StocksServiceTest()
        {
            _stocksService = new StocksService();
        }



        #region CreateBuyOrder

        [Fact]
        public async Task CreateBuyOrder_NullBuyOrderRequest()
        {
            BuyOrderRequest? buyOrderRequest = null;

            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                _stocksService.CreateBuyOrder(buyOrderRequest)
            );
        }

        [Fact]
        public async Task CreateBuyOrder_QuantityIsZero()
        {
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = "StockSymbol",
                StockName = "StockName",
                DateAndTimeOfOrder = new DateTime(2020, 5, 5),
                Price = 100,
                Quantity = 0
            };

            await Assert.ThrowsAsync<ArgumentException>(() =>
                _stocksService.CreateBuyOrder(buyOrderRequest)
            );
        }

        [Fact]
        public async Task CreateBuyOrder_QuantityExceedsMaximum()
        {
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = "StockSymbol",
                StockName = "StockName",
                DateAndTimeOfOrder = new DateTime(2020, 5, 5),
                Price = 100,
                Quantity = 100001
            };

            await Assert.ThrowsAsync<ArgumentException>(() =>
                _stocksService.CreateBuyOrder(buyOrderRequest)
            );
        }

        [Fact]
        public async Task CreateBuyOrder_PriceIsZero()
        {
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = "StockSymbol",
                StockName = "StockName",
                DateAndTimeOfOrder = new DateTime(2020, 5, 5),
                Price = 0,
                Quantity = 20000
            };

            await Assert.ThrowsAsync<ArgumentException>(() =>
                _stocksService.CreateBuyOrder(buyOrderRequest)
            );
        }

        [Fact]
        public async Task CreateBuyOrder_PriceExceedsMaximum()
        {
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = "StockSymbol",
                StockName = "StockName",
                DateAndTimeOfOrder = new DateTime(2020, 5, 5),
                Price = 10001,
                Quantity = 20000
            };

            await Assert.ThrowsAsync<ArgumentException>(() =>
                _stocksService.CreateBuyOrder(buyOrderRequest)
            );
        }

        [Fact]
        public async Task CreateBuyOrder_NullStockSymbol()
        {
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = null,
                StockName = "StockName",
                DateAndTimeOfOrder = new DateTime(2020, 5, 5),
                Price = 100,
                Quantity = 20000
            };

            await Assert.ThrowsAsync<ArgumentException>(() =>
                _stocksService.CreateBuyOrder(buyOrderRequest)
            );
        }

        [Fact]
        public async Task CreateBuyOrder_DateBeforeMinimum()
        {
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = "StockSymbol",
                StockName = "StockName",
                DateAndTimeOfOrder = new DateTime(1999, 12, 31),
                Price = 100,
                Quantity = 20000
            };

            await Assert.ThrowsAsync<ArgumentException>(() =>
                _stocksService.CreateBuyOrder(buyOrderRequest)
            );
        }

        [Fact]
        public async Task CreateBuyOrder_ValidRequest()
        {
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = "StockSymbol",
                StockName = "StockName",
                DateAndTimeOfOrder = new DateTime(2020, 12, 31),
                Price = 100,
                Quantity = 20000
            };

            var buyOrderResponse = await _stocksService.CreateBuyOrder(buyOrderRequest);

            Assert.True(buyOrderResponse.BuyOrderID != Guid.Empty);
        }

        #endregion

        #region CreatSellOrder

        [Fact]
        public async Task CreateSellOrder_NullSellOrderRequest()
        {
            SellOrderRequest? sellOrderRequest = null;

            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                _stocksService.CreateSellOrder(sellOrderRequest));
        }

        [Fact]
        public async Task CreateSellOrder_QuantityIsZero()
        {
            var sellOrderRequest = new SellOrderRequest
            {
                StockSymbol = "StockSymbol",
                StockName = "StockName",
                DateAndTimeOfOrder = new DateTime(2020, 5, 5),
                Price = 100,
                Quantity = 0
            };

            await Assert.ThrowsAsync<ArgumentException>(() =>
                _stocksService.CreateSellOrder(sellOrderRequest));
        }

        [Fact]
        public async Task CreateSellOrder_QuantityExceedsMaximum()
        {
            var sellOrderRequest = new SellOrderRequest
            {
                StockSymbol = "StockSymbol",
                StockName = "StockName",
                DateAndTimeOfOrder = new DateTime(2020, 5, 5),
                Price = 100,
                Quantity = 100001
            };

            await Assert.ThrowsAsync<ArgumentException>(() =>
                _stocksService.CreateSellOrder(sellOrderRequest));
        }

        [Fact]
        public async Task CreateSellOrder_PriceIsZero()
        {
            var sellOrderRequest = new SellOrderRequest
            {
                StockSymbol = "StockSymbol",
                StockName = "StockName",
                DateAndTimeOfOrder = new DateTime(2020, 5, 5),
                Price = 0,
                Quantity = 20000
            };

            await Assert.ThrowsAsync<ArgumentException>(() =>
                _stocksService.CreateSellOrder(sellOrderRequest));
        }

        [Fact]
        public async Task CreateSellOrder_PriceExceedsMaximum()
        {
            var sellOrderRequest = new SellOrderRequest
            {
                StockSymbol = "StockSymbol",
                StockName = "StockName",
                DateAndTimeOfOrder = new DateTime(2020, 5, 5),
                Price = 10001,
                Quantity = 20000
            };

            await Assert.ThrowsAsync<ArgumentException>(() =>
                _stocksService.CreateSellOrder(sellOrderRequest));
        }

        [Fact]
        public async Task CreateSellOrder_NullStockSymbol()
        {
            var sellOrderRequest = new SellOrderRequest
            {
                StockSymbol = null,
                StockName = "StockName",
                DateAndTimeOfOrder = new DateTime(2020, 5, 5),
                Price = 100,
                Quantity = 20000
            };

            await Assert.ThrowsAsync<ArgumentException>(() =>
                _stocksService.CreateSellOrder(sellOrderRequest));
        }

        [Fact]
        public async Task CreateSellOrder_DateBeforeMinimum()
        {
            var sellOrderRequest = new SellOrderRequest
            {
                StockSymbol = "StockSymbol",
                StockName = "StockName",
                DateAndTimeOfOrder = new DateTime(1999, 12, 31),
                Price = 100,
                Quantity = 20000
            };

            await Assert.ThrowsAsync<ArgumentException>(() =>
                _stocksService.CreateSellOrder(sellOrderRequest));
        }

        [Fact]
        public async Task CreateSellOrder_ValidRequest()
        {
            var sellOrderRequest = new SellOrderRequest
            {
                StockSymbol = "StockSymbol",
                StockName = "StockName",
                DateAndTimeOfOrder = new DateTime(2020, 12, 31),
                Price = 100,
                Quantity = 20000
            };

            var sellOrderResponse = await _stocksService.CreateSellOrder(sellOrderRequest);

            Assert.NotEqual(Guid.Empty, sellOrderResponse.SellOrderID);
        }

        #endregion

        #region GetBuyOrders

        [Fact]
        public async Task GetBuyOrders_EmptyList()
        {
            Assert.Empty(await _stocksService.GetBuyOrders());
        }

        [Fact]
        public async Task GetBuyOrders_ReturnsCreatedOrders()
        {
            List<BuyOrderRequest> buyOrderRequests = new List<BuyOrderRequest>()
            {
                new BuyOrderRequest()
                {
                    StockSymbol = "StockSymbol1",
                    StockName = "StockName1",
                    DateAndTimeOfOrder = new DateTime(2020, 12, 31),
                    Price = 100,
                    Quantity = 20000
                },

                new BuyOrderRequest()
                {
                    StockSymbol = "StockSymbol2",
                    StockName = "StockName2",
                    DateAndTimeOfOrder = new DateTime(2024, 1, 2),
                    Price = 120,
                    Quantity = 10000
                },

                new BuyOrderRequest()
                {
                    StockSymbol = "StockSymbol3",
                    StockName = "StockName3",
                    DateAndTimeOfOrder = new DateTime(2016, 5, 8),
                    Price = 220,
                    Quantity = 15000
                }
            };

            List<BuyOrderResponse> expectedBuyOrderResponses = new List<BuyOrderResponse>();

            foreach (var order in buyOrderRequests)
                expectedBuyOrderResponses.Add(await _stocksService.CreateBuyOrder(order));

            List<BuyOrderResponse> actualBuyOrderResponses = await _stocksService.GetBuyOrders();

            foreach (var expectedBuyOrderResponse in expectedBuyOrderResponses)
            {
                Assert.Contains(expectedBuyOrderResponse, actualBuyOrderResponses);
            }
        }

        #endregion

        #region GetSellOrders

        [Fact]
        public async Task GetSellOrders_EmptyList()
        {
            Assert.Empty(await _stocksService.GetSellOrders());
        }

        [Fact]
        public async Task GetSellOrders_ReturnsCreatedOrders()
        {
            List<SellOrderRequest> sellOrderRequests = new List<SellOrderRequest>()
    {
        new SellOrderRequest()
        {
            StockSymbol = "StockSymbol1",
            StockName = "StockName1",
            DateAndTimeOfOrder = new DateTime(2020, 12, 31),
            Price = 100,
            Quantity = 20000
        },
        new SellOrderRequest()
        {
            StockSymbol = "StockSymbol2",
            StockName = "StockName2",
            DateAndTimeOfOrder = new DateTime(2024, 1, 2),
            Price = 120,
            Quantity = 10000
        },
        new SellOrderRequest()
        {
            StockSymbol = "StockSymbol3",
            StockName = "StockName3",
            DateAndTimeOfOrder = new DateTime(2016, 5, 8),
            Price = 220,
            Quantity = 15000
        }
    };

            List<SellOrderResponse> expectedSellOrderResponses = new List<SellOrderResponse>();

            foreach (var order in sellOrderRequests)
                expectedSellOrderResponses.Add(await _stocksService.CreateSellOrder(order));

            List<SellOrderResponse> actualSellOrderResponses = await _stocksService.GetSellOrders();

            foreach (var expectedSellOrderResponse in expectedSellOrderResponses)
            {
                Assert.Contains(expectedSellOrderResponse, actualSellOrderResponses);
            }
        }

        #endregion

    }
}