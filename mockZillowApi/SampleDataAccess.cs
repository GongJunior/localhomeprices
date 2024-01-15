using System.Text.Json;

static class SampleDataAccess
{

    public static async Task<ZillowResponse> GetSampleData(IConfigurationRoot config)
    {
        var sampleDataPath = config.GetConnectionString("SampleDataPath");
        try
        {
            var text = await File.ReadAllTextAsync(
                sampleDataPath ?? throw new FileNotFoundException());
            return JsonSerializer.Deserialize<ZillowResponse>(text) ??
                throw new InvalidDataException();
        }
        catch (Exception ex)
        {
            return new()
            {
                Success = false,
                ErrorMessage = ex.Message
            };
        }
    }
}