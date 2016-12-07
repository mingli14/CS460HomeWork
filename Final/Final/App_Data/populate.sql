
-- ########### Pirates ###########
INSERT INTO [dbo].[Artists](Name,BirthDate,BirthCity)VALUES('M.C.Escher','1898-06-17','Leeuwarden, Netherlands');
INSERT INTO [dbo].[Artists](Name,BirthDate,BirthCity)VALUES('Leonardo Da Vinci','1519-05-02','Vinci, Italy');
INSERT INTO [dbo].[Artists](Name,BirthDate,BirthCity)VALUES('Hatip Mehmed Efendi','1680-11-18','Unknown');
INSERT INTO [dbo].[Artists](Name,BirthDate,BirthCity)VALUES('Salvador Dali','1904-05-11','Figueres, Spain');

-- ########### ArtWorks ###########
INSERT INTO [dbo].[ArtWorks](Title,ArtistID)VALUES('Circle Limit III',1);
INSERT INTO [dbo].[ArtWorks](Title,ArtistID)VALUES('Twon Tree',1);
INSERT INTO [dbo].[ArtWorks](Title,ArtistID)VALUES('Mona Lisa',2);
INSERT INTO [dbo].[ArtWorks](Title,ArtistID)VALUES('The Titruvian Man',2);
INSERT INTO [dbo].[ArtWorks](Title,ArtistID)VALUES('Ebru',3);
INSERT INTO [dbo].[ArtWorks](Title,ArtistID)VALUES('Honey Is Sweeter Than Blood',4);

-- ########### Genres ###########
INSERT INTO [dbo].[Genres](Name)VALUES('Tesselation');
INSERT INTO [dbo].[Genres](Name)VALUES('Surrealism');
INSERT INTO [dbo].[Genres](Name)VALUES('Portrait');
INSERT INTO [dbo].[Genres](Name)VALUES('Renaissance');

-- ########### Crews ###########
INSERT INTO [dbo].[Classifications](ArtWorkID,GenreID)VALUES(1,1);
INSERT INTO [dbo].[Classifications](ArtWorkID,GenreID)VALUES(2,1);
INSERT INTO [dbo].[Classifications](ArtWorkID,GenreID)VALUES(2,2);
INSERT INTO [dbo].[Classifications](ArtWorkID,GenreID)VALUES(3,3);
INSERT INTO [dbo].[Classifications](ArtWorkID,GenreID)VALUES(3,4);
INSERT INTO [dbo].[Classifications](ArtWorkID,GenreID)VALUES(4,4);
INSERT INTO [dbo].[Classifications](ArtWorkID,GenreID)VALUES(5,1);
INSERT INTO [dbo].[Classifications](ArtWorkID,GenreID)VALUES(6,2);
