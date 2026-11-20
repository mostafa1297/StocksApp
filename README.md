# StocksApp

StocksApp is an ASP.NET Core MVC learning project that displays stock prices from Finnhub. It loads the company profile and initial quote through the Finnhub REST API, then updates the displayed price as new trades arrive over a WebSocket connection.

## Features

- Displays the company name, stock symbol, and current price.
- Loads `MSFT` by default. Try another symbol with `/Trade/Index?stockSymbol=AAPL`.
- Updates the displayed price without refreshing the page.
- Includes a service for creating and retrieving simulated buy and sell orders, with xUnit tests for validation and retrieval.

## Run locally

You'll need the .NET 10 SDK and a Finnhub API key.

```bash
git clone https://github.com/mostafa1297/StocksApp.git
cd StocksApp
dotnet user-secrets set "ApiKey" "YOUR_FINNHUB_API_KEY" --project StocksApp/StocksApp.csproj
dotnet run --project StocksApp/StocksApp.csproj
```

Open the local URL printed in the terminal and append `/Trade/Index`. You can change the default symbol in `StocksApp/appsettings.json` under `TradingOptions`.

## Run tests

```bash
dotnet test StocksApp.slnx
```

## Implementation notes

Orders are stored in memory and are cleared when the application restarts. The demo connects to Finnhub directly from the browser for live updates, so the API key is visible in browser developer tools while the page is running.
