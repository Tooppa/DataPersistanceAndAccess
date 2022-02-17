USE SuperheroesDb;

CREATE TABLE SuperheroPower
(
	SuperheroID INT FOREIGN KEY REFERENCES Superhero(ID),
	PowerID INT FOREIGN KEY REFERENCES Power(ID),
	SuperheroPowerID INT PRIMARY KEY (SuperheroID, PowerID)
)
