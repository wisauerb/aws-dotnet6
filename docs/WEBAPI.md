# Create Web API Project

## Setup

* setup .NET6 [README_NET6](README_NET6.md)
* https://blog.danielpadua.dev/posts/creating-a-net-core-webapi-with-swagger-documentation
* note now Swashbuckle included in .NET6 webapp

```bash
dotnet new sln --name TodoApp

dotnet new webapi -o src/TodoApi
dotnet new xunit -o tests/TodoApi.Tests

dotnet sln add src/TodoApi tests/TodoApi.Tests
dotnet add tests/TodoApi.Tests reference src/TodoApi
dotnet add tests/TodoApi.Tests package Moq
dotnet add tests/TodoApi.Tests package Microsoft.AspNetCore.Mvc.Testing

dotnet dev-certs https --trust
```

## Verify Swagger

* https://dotnettutorials.net/lesson/creating-asp-net-core-web-api-project-using-net-core-cli/

```bash
dotnet build
dotnet test
dotnet run --project src/TodoApi/

# info: Microsoft.Hosting.Lifetime[14]
#       Now listening on: https://localhost:7032

open https://localhost:7032/swagger
open https://localhost:7032/WeatherForecast
```

## Test With HttpRepl

```bash
dotnet tool install -g Microsoft.dotnet-httprepl

httprepl https://localhost:7032/swagger
> ls
# .                 []
# WeatherForecast   [GET]

> get WeatherForecast
# HTTP/1.1 200 OK
# ...

> cd WeatherForecast
> get
# HTTP/1.1 200 OK
# ...
```

## Debug

* `Required assets to build and debug are missing from your project. Add them?`
  - `Yes` to add `launch.json` and `tasks.json` in `.vscode`
* left side menu `Run and Debug` > click green start icon to start debug app
  - will open empty https://localhost:7032/ so change to https://localhost:7032/WeatherForecast
* `UnitTest1.cs` > click `Debug Test` under `[Fact]` to start debug test
