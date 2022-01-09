# .NET 6 Rest API Todo Example

* Web API using Dapper and DapperExtensions (instead of EntityFramework)
* based on Microsoft official Web API tutorial
  - https://docs.microsoft.com/ja-jp/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio-code

## Quick Start

```bash
dotnet build
dotnet test
dotnet run --project src/TodoApi/
# Now listening on: https://localhost:7032
open https://localhost:7032/swagger
```

## Initial Setup

* setup .NET6 [docs/NET6](./docs/NET6.md)
* setup Web API Project [docs/WEBAPI](./docs/WEBAPI.md)
* setup local SQL Server [./sqlserver/](./sqlserver/README.md)
