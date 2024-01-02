-- SQLite
SELECT 
    hd.Zestimate, LotAreaUnit, LotAreaValue
FROM 
    requestEvents re
INNER JOIN HousingDetails hd on hd.RequestEventId = re.RequestEventId
WHERE 
    date(RequestTimeUTC) > date(CURRENT_DATE, '-90 days')
    AND
    hd.Zestimate is not null
    AND
    hd.Bedrooms = 999 
    AND
    hd.Bathrooms = 999 
    AND
    hd.ZipCode = '12345'
order by LotAreaValue;
