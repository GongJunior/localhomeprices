-- SQLite
SELECT 
    hd.Zestimate
FROM 
    requestEvents re
INNER JOIN HousingDetails hd on hd.RequestEventId = re.RequestEventId
WHERE 
    date(RequestTimeUTC) > date(CURRENT_DATE, '-90 days')
    AND
    hd.Zestimate is not null
    AND
    hd.Bedrooms = 3;
