FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app

EXPOSE 8080
EXPOSE 8081


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ARG BUILD_CONFIGURATION=Release

WORKDIR /src

COPY ["src/CashWise.Api/CashWise.Api.csproj", "src/CashWise.Api/"]
COPY ["src/CashWise.Application/CashWise.Application.csproj", "src/CashWise.Application/"]
COPY ["src/CashWise.Domain/CashWise.Domain.csproj", "src/CashWise.Domain/"]
COPY ["src/CashWise.Infrastructure/CashWise.Infrastructure.csproj", "src/CashWise.Infrastructure/"]

RUN dotnet restore "src/CashWise.Api/CashWise.Api.csproj"

COPY . .

WORKDIR "/src/src/CashWise.Api"

RUN dotnet build "./CashWise.Api.csproj" \
    -c $BUILD_CONFIGURATION \
    -o /app/build


FROM build AS publish

ARG BUILD_CONFIGURATION=Release

RUN dotnet publish "./CashWise.Api.csproj" \
    -c $BUILD_CONFIGURATION \
    -o /app/publish \
    /p:UseAppHost=false


FROM base AS final

WORKDIR /app

COPY --from=publish /app/publish .

RUN mkdir -p /app/data

RUN chown -R $APP_UID /app/data

USER $APP_UID

ENTRYPOINT ["dotnet", "CashWise.Api.dll"]