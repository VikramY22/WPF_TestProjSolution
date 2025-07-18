-- Создание таблиц
CREATE TABLE Containers (
    ID BIGINT IDENTITY(1,1) PRIMARY KEY,
    Number INT NOT NULL,
    Type NVARCHAR(100) NOT NULL,
    Length DECIMAL(10,2) NULL,
    Width DECIMAL(10,2) NULL,
    Height DECIMAL(10,2) NULL,
    Weight DECIMAL(10,2) NULL,
    IsEmpty BIT NOT NULL,
    ArrivalDate DATETIME NOT NULL
);

CREATE TABLE Operations (
    ID BIGINT IDENTITY(1,1) PRIMARY KEY,
    ContainerID BIGINT NOT NULL,
    OperationStartDate DATETIME NOT NULL,
    OperationEndDate DATETIME NOT NULL,
    OperationType NVARCHAR(200) NOT NULL,
    OperatorFullName NVARCHAR(200) NOT NULL,
    InspectionPlace NVARCHAR(MAX) NOT NULL,
    FOREIGN KEY (ContainerID) REFERENCES Containers(ID)
);

-- Вставка данных
INSERT INTO Containers (
    Number, 
    Type, 
    Length, 
    Width, 
    Height, 
    Weight, 
    IsEmpty, 
    ArrivalDate
)
VALUES (
    123, 
    'Тест', 
    10, 
    10.5, 
    11, 
    1500, 
    1, 
    '2025-07-14T15:30:00'
);

INSERT INTO Operations (
    ContainerID,
    OperationStartDate,
    OperationEndDate,
    OperationType,
    OperatorFullName,
    InspectionPlace
)
VALUES (
    1,
    '2025-07-14T10:00:00',
    '2025-07-14T11:30:00',
    'Погрузка',
    'Иванов И.И.',
    'Склад №1, г. Москва'
);

-- Получение данных
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

-- Получение данных
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
