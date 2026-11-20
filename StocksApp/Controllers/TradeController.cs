using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ServicesConstracts;
using StocksApp.Models;
using StocksApp.Options;
using System.Text.Json;

namespace StocksApp.Controllers
{
    public class TradeController : Controller
    {
        private readonly IStocksService _stocksService;
        private readonly IFinnhubService _finnhubService;
        private readonly TradingOptions _options;

        public TradeController(IStocksService stocksService, IFinnhubService finnhubService, IOptions<TradingOptions> options)
        {
            _stocksService = stocksService;
            _finnhubService = finnhubService;
            _options = options.Value;
        }

        [HttpGet("/Trade/Index")]
        public async Task<IActionResult> Index(string? stockSymbol)
        {
            var selectedSymbol = string.IsNullOrWhiteSpace(stockSymbol) ? _options.DefaultStockSymbol : stockSymbol;

            if (string.IsNullOrWhiteSpace(selectedSymbol))
                return Problem("Default stock symbol is missing.");

            var quote = await _finnhubService.GetStockPriceQuote(selectedSymbol);
            var companyProfile = await _finnhubService.GetCompanyProfile(selectedSymbol);

            if (companyProfile == null)
                return Problem("Finnhub did not return a Company Profile.");

            string? companyName = companyProfile?["name"].ToString();

            if (quote == null)
                return Problem("Finnhub did not return a Stock Price Quote.");

            double currentPrice = ((JsonElement)quote["c"]).GetDouble();


            StockTrade stockTrade = new StockTrade()
            {
                StockSymbol = selectedSymbol,
                StockName = companyName,
                Price = currentPrice,
                Quantity = 1
            };

            return View(stockTrade);
        }
    }
}
