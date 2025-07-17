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
