SELECT 
    '[' + STRING_AGG(
        '{' +
            '"ID":' + CAST(ID AS VARCHAR) + ',' +
            '"Number":' + CAST(Number AS VARCHAR) + ',' +
            '"Type":' + '"' + ISNULL(Type, '') + '",' +
            '"Length":' + ISNULL(CAST(Length AS VARCHAR), 'null') + ',' +
            '"Width":' + ISNULL(CAST(Width AS VARCHAR), 'null') + ',' +
            '"Height":' + ISNULL(CAST(Height AS VARCHAR), 'null') + ',' +
            '"Weight":' + ISNULL(CAST(Weight AS VARCHAR), 'null') + ',' +
            '"IsEmpty":' + CAST(IsEmpty AS VARCHAR) + ',' +
            '"ArrivalDate":' + '"' + CONVERT(VARCHAR, ArrivalDate, 126) + '"' +
        '}'
    , ',') + ']' AS JsonContainers
FROM Containers;