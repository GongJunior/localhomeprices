using System.Text.Json.Serialization;

class HousingDetail
{
    public int HousingDetailID { get; set; }
    public int RequestEventId { get; set; }
    [property: JsonPropertyName("bathrooms")]
    public int? Bathrooms { get; set; }
    [property: JsonPropertyName("bedrooms")]
    public int? Bedrooms { get; set; }
    [property: JsonPropertyName("streetAddress")]
    public string? StreetAddress { get; set; }
    [property: JsonPropertyName("city")]
    public string? City { get; set; }
    [property: JsonPropertyName("state")]
    public string? State { get; set; }
    [property: JsonPropertyName("zipcode")]
    public string? ZipCode { get; set; }
    [property: JsonPropertyName("homeStatus")]
    public string? HomeStatus { get; set; }
    [property: JsonPropertyName("homeType")]
    public string? HomeType { get; set; }
    [property: JsonPropertyName("latitude")]
    public double? Latitude { get; set; }
    [property: JsonPropertyName("longitude")]
    public double? Longitude { get; set; }
    [property: JsonPropertyName("livingArea")]
    public int? LivingArea { get; set; }
    [property: JsonPropertyName("lotAreaUnit")]
    public string? LotAreaUnit { get; set; }
    [property: JsonPropertyName("lotAreaValue")]
    public double? LotAreaValue { get; set; }
    [property: JsonPropertyName("price")]
    public int? Price { get; set; }
    [property: JsonPropertyName("rentZestimate")]
    public int? RentEstimate { get; set; }
    [property: JsonPropertyName("zestimate")]
    public int? Zestimate { get; set; }
    [property: JsonPropertyName("taxAssessedValue")]
    public int? TaxAssessedValue { get; set; }
    [property: JsonPropertyName("imgSrc")]
    public Uri? ImgLink { get; set; }
}