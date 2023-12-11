using System.Text.Json.Serialization;
record ZillowResponse
{
    [property: JsonPropertyName("results")]
    public List<HousingDetail>? ZillowResults { get; set; }

    [property: JsonPropertyName("resultsPerPage")]
    public int ResultsPerPage { get; set; }

    [property: JsonPropertyName("totalPages")]
    public int TotalPages { get; set; }

    [property: JsonPropertyName("totalResultCount")]
    public int ExpectedTotalResultCount { get; set; }
    public Uri? RequestUri { get; set; }
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
}
