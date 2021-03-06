#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CMA.ISMAI.Notifications/CMA.ISMAI.Notifications.csproj", "CMA.ISMAI.Notifications/"]
COPY ["CMA.ISMAI.Core/CMA.ISMAI.Core.csproj", "CMA.ISMAI.Core/"]
COPY ["CMA.ISMAI.Logging/CMA.ISMAI.Logging.csproj", "CMA.ISMAI.Logging/"]
RUN dotnet restore "CMA.ISMAI.Notifications/CMA.ISMAI.Notifications.csproj"
COPY . .
WORKDIR "/src/CMA.ISMAI.Notifications"
RUN dotnet build "CMA.ISMAI.Notifications.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CMA.ISMAI.Notifications.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CMA.ISMAI.Notifications.dll"]