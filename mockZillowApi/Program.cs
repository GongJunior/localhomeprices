using Microsoft.Extensions.Configuration;

var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
var appsettings = Path.Combine(dir.Parent!.FullName, "appapi","appsettings.json");
var config = new ConfigurationBuilder()
    .AddJsonFile(appsettings)
    .Build();

var sampleDataPath = config.GetSection("ConnectionStrings")["SampleDataPath"];

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => SampleDataAccess.GetSampleData(config));

app.Run();
