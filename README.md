# Data Persistance And Access

![GitHub repo size](https://img.shields.io/github/repo-size/Tooppa/DataPersistanceAndAccess)

[SQL Scripts for SuperheroesDb](SuperheroDB)

[Database Diagram of SuperheroesDb](Documentation/SuperheroDb_Diagram.png)

## Table of Contents

- [General Information](#general-information)

- [Technologies](#technologies)

- [Installation and Usage](#installation-and-usage)

- [Contributors](#contributors)

## General Information

This repository contains two separate database related projects, the **SuperheroDB** and the **CustomerDB**. 

The [SuperheroDB](SuperheroDB) is just a collection of SQL scripts that can be used to create a simple database with a few related tables and some example data. The database [diagram](Documentation/SuperheroDb_Diagram.png) depicts the structure of the database.

The [CustomerDB](CustomerDB) on the other hand is a C# console application that implements a repository pattern that can be used to interact with the [Chinook](Assets/Chinook_SqlServer_AutoIncrementPKs.sql) database which includes some example customer data from a digital music store. In the database connection string, the application expects the user to have the Chinook database running on a local SQL Express Server. See [installation and usage](#installation-and-usage) for more details.

**The application provides methods for the following use cases:**

* Display the details of all the customers in the database
* Display the details of a single customer based on their id
* Display the details of a single customer based on their first and last name
* Display the details of a subset of customers based on a given limit and offset
* Add a new customer to the database
* Update the details of an existing customer in the database
* Display a summary of the number of customers by country, ordered from highest to lowest
* Display the names of the customers along with their total amounts of money spent, ordered from highest to lowest
* Display the most popular genre and the amount of tracks for that genre for a given customer id. The most popular just means the genre for which the user has bought the most tracks for. In case of a tie between genres, all of them are displayed.

## Technologies

- C#
- .NET 6
- SQL Client
- SQL Express Server
- SQL Server Management Studio

## Installation and Usage

In order to use the application you need to follow these steps:

1.) Have SQL Express Server and SQL Server Management Studio installed and connect them

2.) Execute the [Chinook](Assets/Chinook_SqlServer_AutoIncrementPKs.sql) SQL script file in SSMS to create the database

3.) Clone the project ```git clone git@github.com:Tooppa/DataPersistanceAndAccess.git```

4.) Open Visual Studio > Select 'Open a project or solution' > Find the project directory and select the **DataPersistanceAndAccess.sln** file

5.) The application should load and be ready for use. You might need to clean/build the solution once to get it working.

6.) The application assumes that the Chinook database instance can be found from an SQL Express Server running on the local machine. That's why the connection string has ```".\\SQLEXPRESS"``` as the DataSource. If there's an error, try changing the DataSource to an explicit connection string.


## Contributors

[Tomas Valkendorff (@Tooppa)](https://github.com/Tooppa)

[Timo Järvenpää (@TimoJarvenpaa)](https://github.com/TimoJarvenpaa)
