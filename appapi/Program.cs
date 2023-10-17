using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    //.WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting up");
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext());

    var connetionString = builder.Configuration.GetConnectionString("HousingDb");
    builder.Services.AddDbContext<HousingDb>(optn => optn.UseSqlite(connetionString));
    builder.Services.AddHttpClient<ZillowService>();
    var app = builder.Build();

    app.MapGet("/", () => "Hello World!");
    app.MapPost("/addaddresses", AddAddressHandler.AddNewAddresses);

    app.Run();

}
catch (System.Exception ex)
{
    Log.Fatal(ex, "Application start-up failed!");
}
finally
{
    Log.CloseAndFlush();
}
