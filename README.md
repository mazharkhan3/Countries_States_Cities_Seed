# WorldData
There are three API. Make sure your identity insert is set to off so that the id's don't mismatch. The API's are as following:
1. Seed Countries
2. Seed States
3. Seed Cities

These API's are built using .NET minimal api's (.NET 6). You can either create your own project and copy over the code or the quickest way would be to clone and attach your database.

**Credit**: [countries-states-cities-database](https://github.com/dr5hn/countries-states-cities-database)

## Connecting a Existing Database
To connect an existing database, the steps are mentioned below:

### 1. Install the following packages
`Install-Package Microsoft.EntityFrameworkCore.SqlServer`

`Install-Package Microsoft.EntityFrameworkCore.Design`

`Install-Package Microsoft.EntityFrameworkCore.Tools`

### 2. Scaffold DbContext
`Scaffold-DbContext "Server=.;Database=YOUR_DATABASE;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context CoreDbContextDataAnnotations`

## 3. Modify the connection string in appsettings.json

## Creating a new database
To create a new database instead of an existing database, the steps are same as mentioned above but the only different one will be the step 2, please see below:

1. Create a Model folder
2. Create a Db context class
3. Create the db models for Country, States and Cities
4. Add those db models to db context class 
5. Run the add migration command
6. Run the update database command

Please note that the points 5 and 6 should be executed after the the step 3 mentioned in the existing database section.



