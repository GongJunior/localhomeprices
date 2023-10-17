record InternalResponse(string? Message, int RecordsAdded = 0, int PagesRemaining = 0, bool Success = true);
record ExternalResponse(string? Message, int RecordsAdded = 0);