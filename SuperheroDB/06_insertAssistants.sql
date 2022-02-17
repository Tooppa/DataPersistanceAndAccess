USE SuperheroesDb;

INSERT INTO Assistant(Name, SuperheroID)
	VALUES ('Robin', (SELECT ID from Superhero WHERE Alias='Batman' ));

INSERT INTO Assistant (Name, SuperheroID)
	VALUES ('Krypto', (SELECT ID from Superhero WHERE Alias='Superman' ));

INSERT INTO Assistant (Name, SuperheroID)
	VALUES ('Oracle', (SELECT ID from Superhero WHERE Alias='Batman' ));

