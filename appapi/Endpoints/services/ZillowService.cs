using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.WebUtilities;

class ZillowService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;
    private readonly ILogger<ZillowService> _logger;
    private readonly string? _baseurl;
    private readonly string? _locationParam;

    public ZillowService(HttpClient httpClient, IConfiguration config, ILogger<ZillowService> logger)
    {
        _httpClient = httpClient;
        _config = config;
        _baseurl = _config.GetSection("zillow")["host"];
        _locationParam = _config.GetSection("zips")["local"];
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new("application/json"));
        _logger = logger;
    }

    public async Task<ZillowResponse> GetHousingDataAsync(int pageNumber = 0)
    {
        if (string.IsNullOrEmpty(_locationParam))
            return FailResponse("No zip code found in configuration!");
        if (string.IsNullOrEmpty(_baseurl))
            return FailResponse("No base url found in configuration!");

        var url = $"https://{_baseurl}/search";
        var queryParams = new Dictionary<string, string?>(){
            {"location" , _locationParam},
            {"output", "json"},
        };
        if (pageNumber > 0)
            queryParams.Add("page", pageNumber.ToString());

        var fullUrl = QueryHelpers.AddQueryString(url, queryParams);
        try
        {
            await using var responseStream = await _httpClient.GetStreamAsync(fullUrl);
            var response = await JsonSerializer.DeserializeAsync<ZillowResponse>(responseStream);
            if (response is null)
                return FailResponse("Error deserializing response!, no results found!");
            return response;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError("HttpRequestException: {@Err} - {@FullErr}", ex.Message, ex);
            return FailResponse("Error making request to Zillow API!", new() { Success = false, ErrorMessage = ex.Message });
        }
        catch (UriFormatException ex)
        {
            _logger.LogError("UriFormatException: {@Err} - {@FullErr}", ex.Message, ex);
            return FailResponse("Error parsing url!", new() { Success = false, ErrorMessage = ex.Message });
        }
        catch (JsonException ex)
        {
            _logger.LogError("JsonException: {@Err} - {@FullErr}", ex.Message, ex);
            return FailResponse("Error deserializing response!", new() { Success = false, ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception: {@Err} - {@FullErr}", ex.Message, ex);
            return FailResponse("Unknown error!", new() { Success = false, ErrorMessage = ex.Message });
        }
    }
    private ZillowResponse FailResponse(string message, ZillowResponse? response = null)
    {
        _logger.LogError("ZillowService: {@Message}", message);
        return response ?? new() { Success = false, ErrorMessage = message };
    }
    // public async Task<ZillowResponse> GetSampleHousingDataAsync()
    // {
    //     var sampleDataPath = _config.GetConnectionString("SampleDataPath");
    //     _logger.LogInformation("Sample data path: {@Spath}", sampleDataPath);
    //     try
    //     {
    //         var text = await File.ReadAllTextAsync(
    //             sampleDataPath ?? throw new FileNotFoundException());
    //         return JsonSerializer.Deserialize<ZillowResponse>(text) ??
    //             throw new InvalidDataException();
    //     }
    //     catch (Exception ex)
    //     {
    //         var message = ex switch
    //         {
    //             FileNotFoundException => "Sample data or connection string not found!",
    //             IOException => "Error reading sample data file!",
    //             InvalidDataException => "Error deserializing sample data!",
    //             _ => "Unknow error!"
    //         };
    //         _logger.LogError("Exception: {@Err} - {@FullErr}", message, ex);
    //         return new ZillowResponse() { Success = false, ErrorMessage = message };
    //     }
    // }
    // public async Task<ZillowResponse> GetSamplePagedData(int pageNumber)
    // {
    //     var result = await GetSampleHousingDataAsync();
    //     return result;
    // }
}