using Services;
using ServicesConstracts;
using StocksApp.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IStocksService, StocksService>();
builder.Services.AddScoped<IFinnhubService, FinnhubService>();

builder.Services.Configure<TradingOptions>
    (builder.Configuration.GetSection("TradingOptions"));

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();



app.Run();
