DECLARE @ContainerID BIGINT = 1;
SELECT 
    '[' + STRING_AGG(
        '{' +
            '"ID":' + CAST(ID AS VARCHAR) + ',' +
            '"ContainerID":' + CAST(ContainerID AS VARCHAR) + ',' +
            '"OperationStartDate":' + '"' + CONVERT(VARCHAR, OperationStartDate, 126) + '",' +
            '"OperationEndDate":' + '"' + CONVERT(VARCHAR, OperationEndDate, 126) + '",' +
            '"OperationType":' + '"' + ISNULL(OperationType, '') + '",' +
            '"OperatorFullName":' + '"' + ISNULL(OperatorFullName, '') + '",' +
            '"InspectionPlace":' + '"' + ISNULL(InspectionPlace, '') + '"' +
        '}'
    , ',') + ']' AS JsonOperations
FROM Operations
WHERE ContainerID = @ContainerID;
