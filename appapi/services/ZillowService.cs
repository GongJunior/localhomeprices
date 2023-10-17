using System.Text.Json;

class ZillowService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;
    private readonly ILogger<ZillowService> _logger;

    public ZillowService(HttpClient httpClient, IConfiguration config, ILogger<ZillowService> logger)
    {
        _httpClient = httpClient;
        _config = config;
        _httpClient.BaseAddress = new Uri("https://www.zillow.com/webservice/");
        _logger = logger;
        _logger.LogInformation("ZillowService initialized! - {@BaseAddress}", _httpClient.BaseAddress);
    }

    public async Task<ZillowResponse> GetHousingDataAsync(){
        throw new NotImplementedException();
    }
    public async Task<ZillowResponse> GetSampleHousingDataAsync()
    {
        var sampleDataPath = _config.GetConnectionString("SampleDataPath");
        _logger.LogInformation("Sample data path: {@Spath}", sampleDataPath);
        try
        {
            var text = await File.ReadAllTextAsync(
                sampleDataPath ?? throw new FileNotFoundException());
            return JsonSerializer.Deserialize<ZillowResponse>(text) ?? 
                throw new InvalidDataException();
        }
        catch (Exception ex)
        {
            var message = ex switch
            {
                FileNotFoundException => "Sample data or connection string not found!",
                IOException => "Error reading sample data file!",
                InvalidDataException => "Error deserializing sample data!",
                _ => "Unknow error!"
            };
            _logger.LogError("Exception: {@Err} - {@FullErr}", message, ex);
            return new ZillowResponse(){Success = false, ErrorMessage = message};
        }
    }
    public async Task<ZillowResponse> GetSamplePagedData(int pageNumber)
    {
        var result = await GetSampleHousingDataAsync();
        return result;
    }
}