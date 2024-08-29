# ClassManagement

## Packages for Solution
- Microsoft.EntityFrameworkCore.Design _ 8.0.8
- Microsoft.EntityFrameworkCore.Relational _ 8.0.8
- Microsoft.EntityFrameworkCore.SqlServer _ 8.0.8
- Microsoft.EntityFrameworkCore.Tools _ 8.0.8
- Swashbuckle.AspNetCore _ 6.7.3
- System.Data.SqlClient _ 4.8.6
- System.Security.Cryptography.Algorithms _ 4.3.1

## Add migration
- cd ClassManagement
- dotnet ef migrations add "InitialDatabase"
- dotnet ef database update

## Remove migration
- dotnet ef migrations remove

## Connect to your local SQL Server
- Create empty database
- Connect to that database you have created with "Tools => Connect to Database" in Visual Studio 2022
- Go to appsettings.json
- Change "Default" in "ConnectionStrings" to your connection string

## Setup Smtp Gmail Sender
Acess to NotiService to read document