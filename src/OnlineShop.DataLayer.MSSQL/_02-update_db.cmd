dotnet tool install --global dotnet-ef --version 3.1.5
dotnet tool update --global dotnet-ef --version 3.1.5
dotnet build
dotnet ef --startup-project "G:\2019\OnlineShop\OnlineShop\src\OnlineShop.Web\OnlineShop.Web.csproj" database update --context MsSqlDbContext
pause