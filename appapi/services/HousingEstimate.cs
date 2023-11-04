using Microsoft.EntityFrameworkCore;
using Serilog;

static class HousingEstimate
{
    private static readonly Serilog.ILogger _logger = Log.ForContext(typeof(HousingEstimate));
    public static async Task<IResult> GetAverageHomeValueAsync(int numBeds, int numBaths, double lotSize, HousingDb db)
    {
        // validate inputs
        try
        {
            // to get median:
                // get collection of values
                // remove nulls
                // order by value
                // if odd, get middle value
                // if even get middle values and average them
                // as much work as possible should be done in the database
            var averageHomeValue = await db.HousingDetails
                .Where(h => h.Bedrooms == numBeds 
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