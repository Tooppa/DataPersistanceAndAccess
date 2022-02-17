USE SuperheroesDb;

INSERT INTO Power (Name, Description)
	VALUES ('Superhuman Strength', 'The power to lift weights beyond what is physically possible for an ordinary human being.');

INSERT INTO Power (Name, Description)
	VALUES ('Flying', 'The power to fly without any outside influence.');

INSERT INTO Power (Name, Description)
	VALUES ('Enhanced Combat', 'The power to possess combat proficiency that of the peak members of their species.');

INSERT INTO Power (Name, Description)
	VALUES ('X-Ray Vision', 'The power to see x-rays.');

INSERT INTO SuperheroPower (SuperheroID, PowerID)
	VALUES (1, 3);

INSERT INTO SuperheroPower (SuperheroID, PowerID)
	VALUES (2, 1);

INSERT INTO SuperheroPower (SuperheroID, PowerID)
	VALUES (2, 2);

INSERT INTO SuperheroPower (SuperheroID, PowerID)
	VALUES (3, 1);