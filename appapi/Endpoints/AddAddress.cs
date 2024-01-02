using Microsoft.EntityFrameworkCore;
using Serilog;

static class AddAddress
{
    private static readonly Serilog.ILogger _logger = Log.ForContext(typeof(AddAddress));
    public static async Task<IResult> AddNewAddresses(SearchParam param, ZillowService zillow, HousingDb db, IConfiguration config)
    {
        var groupHash = new Guid().ToString();
        int totalRecordsAdded;
        _logger.Information("AddNewAddresses: {@Param}", param);

        if (param.ParamType != "zip")
            return TypedResults.BadRequest(GetResponse("Invalid request!"));

        var (hasCallsRemainig, numCallsRemaing) = await HasZillowCallsRemainingAsync(db, config);
        if (hasCallsRemainig == false)
            return TypedResults.BadRequest(GetResponse("Max monthly requests reached!"));

        var initialResponse = await AddRequestResultsToDatabaseAsync(await zillow.GetSampleHousingDataAsync(), db, groupHash);
        numCallsRemaing--;
        _logger.Information("Initial Response: {@Response}", initialResponse);

        if (initialResponse.RecordsAdded == 0)
            return TypedResults.NotFound(GetResponse("No results found!"));

        totalRecordsAdded = initialResponse.RecordsAdded;
        if (initialResponse.PagesRemaining == 0 || numCallsRemaing == 0)
            return TypedResults.Ok(GetResponse($"Total pages processed: 1", totalRecordsAdded));

        for (int i = 2; i <= initialResponse.PagesRemaining; i++)
        {
            _logger.Information("Processing page: {@Page}", i);
            if (numCallsRemaing == 0)
                break;
            var pagedResponse = await AddRequestResultsToDatabaseAsync(await zillow.GetSamplePagedData(i), db, groupHash);
            numCallsRemaing--;
            if (pagedResponse.RecordsAdded == 0)
                return TypedResults.Ok(GetResponse($"Total pages processed: {i + 1}", totalRecordsAdded));
            totalRecordsAdded += pagedResponse.RecordsAdded;
            await Task.Delay(1000);
        }

        return TypedResults.Ok(GetResponse($"Records added", totalRecordsAdded));
    }
    private static AddAddressExternalResponse GetResponse(string message, int recordsAdded = 0)
    {
        return new AddAddressExternalResponse(message, recordsAdded);
    }
    private static RequestEvent GetRequestEvent(ZillowResponse zillowResponse, string groupHash)
    {
        return new RequestEvent
        {
            RequestUri = zillowResponse.RequestUri ?? new("http://localhost"),
            RequestGroupHash = groupHash,
            RequestTimeUTC = DateTime.UtcNow,
            Success = zillowResponse.Success,
            ErrorMessage = zillowResponse.ErrorMessage,
            RequestEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "dev",
            ExpectedTotalResults = zillowResponse.ExpectedTotalResultCount,
            ActualTotalResults = zillowResponse.ZillowResults?.Count ?? 0,
            HousingDetails = zillowResponse.ZillowResults
        };
    }
    private static async Task<AddAddressInternalResponse> AddRequestResultsToDatabaseAsync(ZillowResponse zillowResponse, HousingDb db, string groupHash)
    {
        var requestEvent = GetRequestEvent(zillowResponse, groupHash);
        var numRecords = zillowResponse.ZillowResults?.Count ?? 0;
        try
        {
            db.RequestEvents.Add(requestEvent);
            await db.SaveChangesAsync();
            return new(null, numRecords, zillowResponse.TotalPages);
        }
        catch (Exception ex)
        {
            _logger.Information("Exception: {@Err} - {@FullErr}", ex.Message, ex);
            return new(null, numRecords, 0, false);
        }
    }

    private static async Task<(bool hasRemainig, int numRemaing)> HasZillowCallsRemainingAsync(HousingDb db, IConfiguration config)
    {
        var maxRequests = config.GetValue<int>("zillow:MaxMonthlyRequests");
        try
        {
            var numMonthlyRequets = await db.RequestEvents.Where(r => r.RequestTimeUTC >= DateTime.UtcNow.AddDays(-31)).ToListAsync();
            return (numMonthlyRequets.Count < maxRequests, maxRequests - numMonthlyRequets.Count);

        }
        catch (Exception ex)
        {
            _logger.Information("Max Requets: {@MaxReqs}; Exception: {@Err} - {@FullErr}", maxRequests, ex.Message, ex);
            return (false, 0);
        }
    }
}