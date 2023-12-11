// using System.Text.Json.Serialization;

// class ZillowResult
// {
//     [property: JsonPropertyName("bathrooms")]
//     public long? Bathrooms { get; set; }

//     [property: JsonPropertyName("bedrooms")]
//     public long? Bedrooms { get; set; }

//     [property: JsonPropertyName("city")]
//     public string? City { get; set; }

//     [property: JsonPropertyName("comingSoonOnMarketDate")]
//     public long? ComingSoonOnMarketDate { get; set; }

//     [property: JsonPropertyName("country")]
//     public Country Country { get; set; }

//     [property: JsonPropertyName("currency")]
//     public Currency Currency { get; set; }

//     [property: JsonPropertyName("daysOnZillow")]
//     public long DaysOnZillow { get; set; }

//     [property: JsonPropertyName("homeStatus")]
//     public HomeStatus HomeStatus { get; set; }

//     [property: JsonPropertyName("homeStatusForHDP")]
//     public HomeStatus HomeStatusForHdp { get; set; }

//     [property: JsonPropertyName("homeType")]
//     public HomeType HomeType { get; set; }

//     [property: JsonPropertyName("imgSrc")]
//     public Uri ImgSrc { get; set; }

//     [property: JsonPropertyName("isFeatured")]
//     public bool IsFeatured { get; set; }

//     [property: JsonPropertyName("isNonOwnerOccupied")]
//     public bool IsNonOwnerOccupied { get; set; }

//     [property: JsonPropertyName("isPreforeclosureAuction")]
//     public bool IsPreforeclosureAuction { get; set; }

//     [property: JsonPropertyName("isPremierBuilder")]
//     public bool IsPremierBuilder { get; set; }

//     [property: JsonPropertyName("isShowcaseListing")]
//     public bool IsShowcaseListing { get; set; }

//     [property: JsonPropertyName("isUnmappable")]
//     public bool IsUnmappable { get; set; }

//     [property: JsonPropertyName("isZillowOwned")]
//     public bool IsZillowOwned { get; set; }

//     [property: JsonPropertyName("latitude")]
//     public double Latitude { get; set; }

//     [property: JsonPropertyName("listing_sub_type")]
//     public ListingSubType ListingSubType { get; set; }

//     [property: JsonPropertyName("livingArea", NullValueHandling = NullValueHandling.Ignore)]
//     public long? LivingArea { get; set; }

//     [property: JsonPropertyName("longitude")]
//     public double Longitude { get; set; }

//     [property: JsonPropertyName("lotAreaUnit", NullValueHandling = NullValueHandling.Ignore)]
//     public LotAreaUnit? LotAreaUnit { get; set; }

//     [property: JsonPropertyName("lotAreaValue", NullValueHandling = NullValueHandling.Ignore)]
//     public double? LotAreaValue { get; set; }

//     [property: JsonPropertyName("price")]
//     public long Price { get; set; }

//     [property: JsonPropertyName("priceForHDP")]
//     public long PriceForHdp { get; set; }

//     [property: JsonPropertyName("rentZestimate", NullValueHandling = NullValueHandling.Ignore)]
//     public long? RentZestimate { get; set; }

//     [property: JsonPropertyName("shouldHighlight")]
//     public bool ShouldHighlight { get; set; }

//     [property: JsonPropertyName("state")]
//     public string? State { get; set; }

//     [property: JsonPropertyName("streetAddress")]
//     public string StreetAddress { get; set; }

//     [property: JsonPropertyName("taxAssessedValue", NullValueHandling = NullValueHandling.Ignore)]
//     public long? TaxAssessedValue { get; set; }

//     [property: JsonPropertyName("zestimate", NullValueHandling = NullValueHandling.Ignore)]
//     public long? Zestimate { get; set; }

//     [property: JsonPropertyName("zipcode")]
//     [JsonConverter(typeof(ParseStringConverter))]
//     public long Zipcode { get; set; }

//     [property: JsonPropertyName("zpid")]
//     public long Zpid { get; set; }

//     [property: JsonPropertyName("newConstructionType", NullValueHandling = NullValueHandling.Ignore)]
//     public NewConstructionType? NewConstructionType { get; set; }

//     [property: JsonPropertyName("datePriceChanged", NullValueHandling = NullValueHandling.Ignore)]
//     public long? DatePriceChanged { get; set; }

//     [property: JsonPropertyName("group_type", NullValueHandling = NullValueHandling.Ignore)]
//     public string GroupType { get; set; }

//     [property: JsonPropertyName("priceChange", NullValueHandling = NullValueHandling.Ignore)]
//     public long? PriceChange { get; set; }

//     [property: JsonPropertyName("priceSuffix", NullValueHandling = NullValueHandling.Ignore)]
//     public string PriceSuffix { get; set; }

//     [property: JsonPropertyName("providerListingID", NullValueHandling = NullValueHandling.Ignore)]
//     [JsonConverter(typeof(ParseStringConverter))]
//     public long? ProviderListingId { get; set; }

//     [property: JsonPropertyName("unit", NullValueHandling = NullValueHandling.Ignore)]
//     public string Unit { get; set; }

//     [property: JsonPropertyName("priceReduction", NullValueHandling = NullValueHandling.Ignore)]
//     public string PriceReduction { get; set; }

//     [property: JsonPropertyName("openHouse", NullValueHandling = NullValueHandling.Ignore)]
//     public string OpenHouse { get; set; }

//     [property: JsonPropertyName("open_house_info", NullValueHandling = NullValueHandling.Ignore)]
//     public OpenHouseInfo OpenHouseInfo { get; set; }
// }