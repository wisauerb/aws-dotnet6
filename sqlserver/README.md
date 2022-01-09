# Setup Local SQL Server

## Start SQL Server

* https://hub.docker.com/_/microsoft-mssql-server

```bash
docker-compose --version
# docker-compose version 1.29.2, build 5becea4c

# start Express server
docker-compose up -d

docker-compose ps
docker-compose logs -f

# it will create DemoDB database
# check inside container
docker exec -it mssql bash
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P yourStrong_Password
> sp_databases
> go
```

## Setup Schema

```bash
brew install flyway

flyway --version
# Flyway Community Edition 8.4.0 by Redgate

flyway baseline
flyway info
# ... << Flyway Baseline >> ...

# run sql
flyway migrate

# undo sql when failed
flyway repair
```

## Clean Up

```bash
docker-compose down
```
