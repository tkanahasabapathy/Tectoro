IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'Tectoro')
BEGIN
	CREATE DATABASE Tectoro
END
GO

USE Tectoro
GO

IF OBJECT_ID ('dbo.Clients', 'U') IS NOT NULL  
   DROP TABLE Clients;  
GO 

IF OBJECT_ID ('dbo.Managers', 'U') IS NOT NULL  
   DROP TABLE Managers;  
GO 

IF OBJECT_ID ('dbo.Users', 'U') IS NOT NULL  
   DROP TABLE Users;  
GO 

CREATE TABLE [dbo].[Users] (
	[UserId] INT IDENTITY (1, 1) NOT NULL,
	[UserName] NVARCHAR (200) NOT NULL,
	[Email] NVARCHAR (1000) NULL,
	[Alias] NVARCHAR (1000) NULL,
	[FirstName] NVARCHAR (1000) NULL,
	[LastName] NVARCHAR (1000) NULL
CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserId] ASC))
GO

CREATE TABLE [dbo].[Managers] (
	[ManagerId] INT IDENTITY (1, 1) NOT NULL,
	[UserId] INT NOT NULL, 
	[Position] NVARCHAR (100) NOT NULL
	CONSTRAINT [PK_Managers] PRIMARY KEY CLUSTERED ([ManagerId] ASC),
	CONSTRAINT FK_Managers_Users FOREIGN KEY (UserId) 
		REFERENCES dbo.Users(UserId)
)
GO

CREATE TABLE [dbo].[Clients] (
	[ClientId] INT IDENTITY (1, 1) NOT NULL,
	[UserId] INT NOT NULL, 
	[Level] INT NOT NULL,
	[ManagerId] INT NOT NULL
	CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED ([ClientId] ASC),
	CONSTRAINT FK_Clients_Users FOREIGN KEY (UserId) 
		REFERENCES dbo.Users(userID),
	CONSTRAINT FK_Clients_Managers FOREIGN KEY (ManagerId) 
		REFERENCES dbo.Managers(ManagerId)
)
GO



INSERT INTO Users 
SELECT 'sabapathy', 'saba@tectoro.com', 'saba', 'Kanaga', 'Sabapathy'
UNION
SELECT 'viswavedant', 'viswa@tectoro.com', 'vedant', 'Viswa', 'Vedant'
UNION
SELECT 'viswaadvait', 'advait@tectoro.com', 'advait', 'Viswa', 'Advait'
UNION
SELECT 'premkumar', 'prem@tectoro.com', 'prem', 'Prem', 'Kumar'
UNION
SELECT 'tracywitney', 'tracy@tectoro.com', 'tracy', 'Tracy', 'Witney'
UNION
SELECT 'willsmith', 'will@tectoro.com', 'will', 'Will', 'Smith'
UNION
SELECT 'johnwilliam', 'john@tectoro.com', 'john', 'John', 'William'
UNION
SELECT 'lauradutt', 'laura@tectoro.com', 'laura', 'Laura', 'Dutt'
UNION
SELECT 'steveharris', 'steve@tectoro.com', 'steve', 'Steve', 'Harris'
UNION
SELECT 'benwalter', 'ben@tectoro.com', 'ben', 'Ben', 'Walter'
GO

INSERT INTO Managers
SELECT 1, 'Senior'
UNION
SELECT 2, 'Junior'
UNION
SELECT 3, 'Junior'

INSERT INTO Clients
SELECT 4, 1, 1
UNION
SELECT 5, 3, 1
UNION
SELECT 6, 2, 2
UNION
SELECT 7, 1, 2
UNION
SELECT 8, 2, 2
UNION
SELECT 9, 3, 3
UNION
SELECT 10, 3, 3


SELECT * FROM Users
SELECT * FROM Managers
SELECT * FROM Clients