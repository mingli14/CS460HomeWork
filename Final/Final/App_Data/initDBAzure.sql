IF OBJECT_ID('dbo.Artists','U') IS NOT NULL
	DROP TABLE [dbo].[Artists];
GO

IF OBJECT_ID('dbo.ArtWorks','U') IS NOT NULL
	DROP TABLE [dbo].[ArtWorks];
GO

IF OBJECT_ID('dbo.Genres','U') IS NOT NULL
	DROP TABLE [dbo].[Genres];
GO

IF OBJECT_ID('dbo.Classifications','U') IS NOT NULL
	DROP TABLE [dbo].[Classifications];
GO

-- ########### Artists ###########
CREATE TABLE [dbo].[Artists]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[Name] NVARCHAR (50) NOT NULL,
	[BirthDate] DATE NOT NULL,
	[BirthCity] NVARCHAR (50) NOT NULL,
	CONSTRAINT [PK_dbo.Artists] PRIMARY KEY CLUSTERED ([ID] ASC)
);

-- ########### ArtWorks ###########
CREATE TABLE [dbo].[ArtWorks]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[ArtistID] INT NOT NULL,
	CONSTRAINT [PK_dbo.ArtWorks] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.ArtWorks_dbo.Artists_ID] FOREIGN KEY ([ArtistID]) REFERENCES [dbo].[Artists] ([ID])
);

-- ########### Genres ###########
CREATE TABLE [dbo].[Genres]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	CONSTRAINT [PK_dbo.Genres] PRIMARY KEY CLUSTERED ([ID] ASC)
);

-- ########### Classifications ###########
CREATE TABLE [dbo].[Classifications]
(
	[ID] INT IDENTITY (1,1) NOT NULL,
	[ArtWorkID] INT NOT NULL,
	[GenreID] INT NOT NULL,
	CONSTRAINT [PK_dbo.Classifications] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Classifications_dbo.ArtWorks_ID] FOREIGN KEY ([ArtWorkID]) REFERENCES [dbo].[ArtWorks] ([ID]),
	CONSTRAINT [FK_dbo.Classifications_dbo.Genres_ID] FOREIGN KEY ([GenreID]) REFERENCES [dbo].[Genres] ([ID])
);