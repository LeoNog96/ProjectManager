FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /src

COPY ProjectManager.Backend.sln ./
COPY ProjectManager.Entities/*.csproj ./ProjectManager.Entities/
COPY ProjectManager.Repositories/*.csproj ./ProjectManager.Repositories/
COPY ProjectManager.Tests/*.csproj ./ProjectManager.Tests/
COPY ProjectManager.Core/*.csproj ./ProjectManager.Core/

RUN dotnet restore

COPY . .

RUN dotnet test

WORKDIR /src/ProjectManager.Entities
RUN dotnet build -c Release -o /app

WORKDIR /src/ProjectManager.Repositories
RUN dotnet build -c Release -o /app

WORKDIR /src/ProjectManager.Tests
RUN dotnet build -c Release -o /app

WORKDIR /src/ProjectManager.Core
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final

ENV TZ=America/Sao_Paulo
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProjectManager.Core.dll"]