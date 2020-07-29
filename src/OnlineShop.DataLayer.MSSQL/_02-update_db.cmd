dotnet tool install --global dotnet-ef --version 3.1.5
dotnet tool update --global dotnet-ef --version 3.1.5
dotnet build
dotnet ef --startup-project ../OnlineShop/ database update --context MsSqlDbContext
pause