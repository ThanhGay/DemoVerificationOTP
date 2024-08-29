# ClassManagement

### Add migration
cd ClassManagement
dotnet ef migrations add "InitialDatabase"
dotnet ef database update
dotnet ef migrations remove

### Connect to your local SQL Server
- Create empty database
- Config to connect that database you have created with "Tools" in Visual Studio 2022
- Go to appsettings.json
- Change "Default" in "ConnectionStrings" to your connection string