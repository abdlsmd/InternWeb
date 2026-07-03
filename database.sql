-- Run this against your SQL Server instance (matches appsettings.json: Database=InternDB)
CREATE DATABASE InternDB;
GO

USE InternDB;
GO

CREATE TABLE Interns (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL,
    Department NVARCHAR(100) NOT NULL,
    DurationInMonths INT NOT NULL
);
GO
