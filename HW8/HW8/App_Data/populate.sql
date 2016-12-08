
-- ########### Pirates ###########
INSERT INTO [dbo].[Pirates](Name,Conscripted)VALUES('James',2002-09-01);
INSERT INTO [dbo].[Pirates](Name,Conscripted)VALUES('Joseph',2001-04-01);
INSERT INTO [dbo].[Pirates](Name,Conscripted)VALUES('Duncan',2003-02-01);
INSERT INTO [dbo].[Pirates](Name,Conscripted)VALUES('Robert',2004-09-01);
INSERT INTO [dbo].[Pirates](Name,Conscripted)VALUES('Jason',2002-09-15);

-- ########### Ships ###########
INSERT INTO [dbo].[Ships](Name,Type,Tonnage)VALUES('Queen Anne''s Revenge','Frigate',200);
INSERT INTO [dbo].[Ships](Name,Type,Tonnage)VALUES('Freedom','Frigate',300);
INSERT INTO [dbo].[Ships](Name,Type,Tonnage)VALUES('Sunlight','Frigate',150);
INSERT INTO [dbo].[Ships](Name,Type,Tonnage)VALUES('Mountain','Frigate',170);
INSERT INTO [dbo].[Ships](Name,Type,Tonnage)VALUES('Water','Frigate',190);

-- ########### Crews ###########
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(100,1,1);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(200,1,2);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(300,1,3);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(140,1,4);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(130,1,5);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(150,2,1);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(100,2,2);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(140,2,3);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(200,2,4);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(210,3,3);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(220,3,4);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(130,3,5);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(140,4,1);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(100,4,2);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(200,4,3);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(230,4,4);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(150,4,5);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(100,5,1);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(230,5,3);
INSERT INTO [dbo].[Crews](Booty,PirateID,ShipID)VALUES(150,5,5);