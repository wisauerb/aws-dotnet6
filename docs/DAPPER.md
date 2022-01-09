# Setup Dapper

## Setup Nuget Packages

```bash
dotnet add src/TodoApi package Dapper
dotnet add src/TodoApi package Microsoft.Data.SqlClient
dotnet add src/TodoApi package Dapper.SimpleCRUD
```

__other dapper extension library notes__

* `Dapper.Contrib` expects table name plural so rejected
* `DapperExtensions` no custom mapping by attribute so rejected

## Trouble Shooting

```
Microsoft.Data.SqlClient.SqlException (0x80131904):
A connection was successfully established with the server,
but then an error occurred during the pre-login handshake.
```

* `;TrustServerCertificate=true` required in the connection string
  - c.f. https://stackoverflow.com/questions/3270199

## Reference

* https://mebee.info/2021/11/30/post-36023/
* https://code-maze.com/using-dapper-with-asp-net-core-web-api/
* https://www.youtube.com/watch?v=5tYSO5mAjXs
