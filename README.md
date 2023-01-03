# SQLiteTestApi

# Prerequisites
Visual Studio 2019 version 16.3 or later.

# Install Entity Framework Core
To install EF Core, you install the package for the EF Core database provider(s) you want to target. We use SQLite because it runs on all platforms that .NET Core supports.
Tools > NuGet Package Manager > Package Manager Console
Run the following commands:
Install-Package Microsoft.EntityFrameworkCore.Sqlite

# Create the database
The following steps use migrations to create a database.
Run the following commands in Package Manager Console (PMC)
--> Install-Package Microsoft.EntityFrameworkCore.Tools
--> Add-Migration InitialCreate
--> Update-Database

* The Add-Migration command scaffolds a migration to create the initial set of tables for the model. 
* The Update-Database command creates the database and applies the new migration to it.
