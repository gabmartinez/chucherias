# konoha
Proyecto Final de Programación 3 utilizando Asp .Net

## Initial Migration
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Create migrations for updates
```bash
dotnet ef migrations add [MigrationName]
dotnet ef database update
```

## Add new update to database
```bash
dotnet ef database update
```

## Docker MS SQL SERVER
```bash
docker pull microsoft/mssql-server-linux
docker run --name mssql-server -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=<Password>' -e 'MSSQL_PID=Express' -p 127.0.0.1:1433:1433 -d microsoft/mssql-server-linux:latest
```

## Developer Env
```bash
export ASPNETCORE_ENVIRONMENT=Development && dotnet run
```

## Facebook configurations
```bash
dotnet user-secrets set Authentication:Facebook:AppId <AppId>
dotnet user-secrets set Authentication:Facebook:AppSecret <AppSecret>
```