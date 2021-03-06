USE SuperheroesDb;

CREATE TABLE Superhero(
	ID INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50),
	Alias NVARCHAR(50),
	Origin NVARCHAR(50)
)
CREATE TABLE Assistant(
	ID INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50)
)
CREATE TABLE Power(
	ID INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50),
	Description NVARCHAR(100)
)