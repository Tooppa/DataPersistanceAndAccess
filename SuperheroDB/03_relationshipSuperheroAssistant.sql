USE SuperheroesDb;

ALTER TABLE Assistant
	ADD SuperheroID int CONSTRAINT FK_ASSISTANT_SUPERHERO FOREIGN KEY REFERENCES Superhero(ID);