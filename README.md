# ProjectMananger

## Tecnologias Utilizadas

- dotnet core >= 3.0
- Postgresql >= 12
- VueJs >= 2.x

### Restore project Dependences
```
dotnet restore
```

### Build project
```
dotnet build
```

### Build docker
```
docker build .
```

### Run test project
```
dotnet test
```

### Run project for development
```
dotnet run --project TaskManager.api/TaskManager.api.csproj
```

### Publish project production
```
dotnet publish --release
```