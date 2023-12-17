using Microsoft.EntityFrameworkCore;
using Serilog;

static class GetEstimate
{
    private static readonly Serilog.ILogger _logger = Log.ForContext(typeof(GetEstimate));
    public static async Task<IResult> GetAverageHomeValueAsync(int zip, int numBeds, int numBaths, double lotSize, HousingDb db)
    {
        // validate inputs
        try
        {
            var averageHomeValue = await db.HousingDetails
                .Where(h => h.Bedrooms == numBeds
                && h.ZipCode == zip.ToString()
                && h.Bathrooms == numBaths
                && h.LotAreaUnit == "acres"
                && h.LotAreaValue > lotSize
                && h.Zestimate != null)
                .Select(h => h.Zestimate)
                .AverageAsync();
            return TypedResults.Ok(averageHomeValue);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error getting median home value");
            return TypedResults.BadRequest("Error getting median home value");
        }
    }

}