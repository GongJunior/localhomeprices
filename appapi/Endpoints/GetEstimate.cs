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
<<<<<<< HEAD:appapi/Endpoints/HousingEstimate.cs
            var query = db.RequestEvents
                .Where(r => r.RequestTimeUTC >= DateTime.UtcNow.AddDays(-91))
                .Include(
                    req => req.HousingDetails!.Where(
                        hd => hd.ZipCode == zip.ToString()
                        && hd.Bedrooms == numBeds
                        && hd.Bathrooms == numBaths
                        // && hd.LotAreaUnit == "acres"
                        // && hd.LotAreaValue >= (lotSize - lotSize * .5)
                        // && hd.LotAreaValue <= (lotSize + lotSize * .5)
                        && hd.Zestimate != null
                    )
                );
            var results = await query.ToListAsync();
            var zestimates = results.SelectMany(req => req.HousingDetails!.Select(hd => hd.Zestimate ?? 0));
            var count = zestimates.Count();
            var estimate = count != 0 ? zestimates.Average() : 0;
            return TypedResults.Ok(new { estimate, count, message = "Success" });
=======
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
>>>>>>> 4918bbefa18aee130e99b946457141893f7dcf4a:appapi/Endpoints/GetEstimate.cs
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error getting median home value");
            return TypedResults.BadRequest(new { estimate = 0, count = 0, message = "Error getting median home value" });
        }
    }

}