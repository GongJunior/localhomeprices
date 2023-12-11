record AddAddressInternalResponse(string? Message, int RecordsAdded = 0, int PagesRemaining = 0, bool Success = true);
record AddAddressExternalResponse(string? Message, int RecordsAdded = 0);
record EstimateInternalResponse(string? Message, int? Estimate = null, bool Success = true);
record EstimateExternalResponse(string? Message, int? Estimate = null, int? ComparableListingsFound = 0);