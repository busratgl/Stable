#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Stable.API/Stable.API.csproj", "Stable.API/"]
COPY ["Stable.Business/Stable.Business.csproj", "Stable.Business/"]
COPY ["Stable.Repository/Stable.Repository.csproj", "Stable.Repository/"]
COPY ["Stable.Core/Stable.Core.csproj", "Stable.Core/"]
COPY ["Stable.Entity/Stable.Entity.csproj", "Stable.Entity/"]
RUN dotnet restore "Stable.API/Stable.API.csproj"
COPY . .
WORKDIR "/src/Stable.API"
RUN dotnet build "Stable.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Stable.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Stable.API.dll"]