-- Create tables and populate with seed data
--    follow naming convention: "Users" table contains rows that are each "User" objects

-- ***********  Attach ***********
CREATE DATABASE [Example] ON
PRIMARY (NAME=[Example], FILENAME='$(dbdir)\Example.mdf')
LOG ON (NAME=[Example_log], FILENAME='$(dbdir)\Example_log.ldf');
--FOR ATTACH;
GO

USE [Example];
GO

-- *********** Drop Tables ***********

IF OBJECT_ID('dbo.Requests','U') IS NOT NULL
	DROP TABLE [dbo].[Requests];
GO


-- ########### Users ###########
CREATE TABLE [dbo].[Requests]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[FirstName] NVARCHAR (50) NOT NULL,
	[LastName] NVARCHAR (50) NOT NULL,
	[DOB] DATETIME NOT NULL,
    [PhoneNumber] NVARCHAR (50) NOT NULL,
	[CatalogYear] DATETIME NOT NULL,
	[VNumber] NVARCHAR (50) NOT NULL,
	[Email] NVARCHAR (50) NOT NULL,
	[Major] NVARCHAR (50) NOT NULL,
	[Minor] NVARCHAR (50) NOT NULL,
	[Advisor] NVARCHAR (50) NOT NULL,
	CONSTRAINT [PK_dbo.Requests] PRIMARY KEY CLUSTERED ([ID] ASC)
);

BULK INSERT [dbo].[Requests]
	FROM '$(dbdir)\SeedData\Requests.csv'		
	WITH
	(
		FIELDTERMINATOR = ',',
		ROWTERMINATOR	= '\n',
		FIRSTROW = 2
	);
GO

-- ***********  Detach ***********
USE master;
GO

ALTER DATABASE [Example] SET SINGLE_REQUEST WITH ROLLBACK IMMEDIATE
GO

EXEC sp_detach_db 'Example', 'true'