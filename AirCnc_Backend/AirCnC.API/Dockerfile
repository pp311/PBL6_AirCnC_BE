﻿FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AirCnC.API/AirCnC.API.csproj", "AirCnC.API/"]
COPY ["AirCnC.Application/AirCnC.Application.csproj", "AirCnC.Application/"]
COPY ["AirCnC.Domain/AirCnC.Domain.csproj", "AirCnC.Domain/"]
COPY ["AirCnC.Infrastructure/AirCnC.Infrastructure.csproj", "AirCnC.Infrastructure/"]
RUN dotnet restore "AirCnC.API/AirCnC.API.csproj"
COPY . .
WORKDIR "/src/AirCnC.API"
RUN dotnet build "AirCnC.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AirCnC.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AirCnC.API.dll"]
