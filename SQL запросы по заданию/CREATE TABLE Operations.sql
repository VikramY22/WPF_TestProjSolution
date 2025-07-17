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
