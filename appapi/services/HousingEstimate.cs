using Serilog;

static class HousingEstimate
{
    private static readonly Serilog.ILogger _logger = Log.ForContext(typeof(HousingEstimate));
    public static async Task<IResult> GetMedianHomeValueAsync(int numBeds, int numBaths, double lotSize)
    {
        try
        {
            var zillowService = new ZillowService();
            var medianHomeValue = await zillowService.GetMedianHomeValue(numBeds, numBaths, lotSize);
            return Results.Ok(medianHomeValue);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error getting median home value");
            return Results.Error(ex.Message);
        }
    }
    
}