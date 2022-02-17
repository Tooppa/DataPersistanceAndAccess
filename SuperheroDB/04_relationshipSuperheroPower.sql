USE SuperheroesDb;

CREATE TABLE SuperheroPower
(
	SuperheroID INT,
	PowerID INT,
	CONSTRAINT SuperheroPowerID PRIMARY KEY (SuperheroID, PowerID),
	CONSTRAINT FK_SuperheroPower_Superhero FOREIGN KEY(SuperheroID) REFERENCES Superhero (ID),
	CONSTRAINT FK_SuperheroPower_Power FOREIGN KEY(PowerID) REFERENCES Power (ID)
)
