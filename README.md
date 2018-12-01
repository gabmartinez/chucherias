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