class RequestEvent
{
    public int RequestEventId { get; set; }
    public required Uri RequestUri {get; set;}
    public required string RequestGroupHash { get; set; }
    public required DateTime RequestTimeUTC { get; set; }
    public required bool Success { get; set; }
    public string? ErrorMessage { get; set; }
    public required string RequestEnvironment { get; set; }
    public int ExpectedTotalResults { get; set; }
    public int ActualTotalResults { get; set; }
    public ICollection<HousingDetail>? HousingDetails { get; set; }
}