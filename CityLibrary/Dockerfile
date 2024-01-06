ARG ASPNET_VERSION=5.0
ARG SDK_VERSION=5.0

FROM mcr.microsoft.com/dotnet/aspnet:${ASPNET_VERSION} AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:${SDK_VERSION} AS build
WORKDIR /app
COPY . .

RUN dotnet restore "CityLibrary.Domain/CityLibrary.Domain.csproj" && \
    dotnet build "CityLibrary.Domain/CityLibrary.Domain.csproj" -c Release

RUN dotnet restore "CityLibrary.Persistence/CityLibrary.Persistence.csproj" && \
    dotnet build "CityLibrary.Persistence/CityLibrary.Persistence.csproj" -c Release

RUN dotnet restore "CityLibrary.API/CityLibrary.API.csproj" && \
    dotnet build "CityLibrary.API/CityLibrary.API.csproj" -c Release

FROM build AS publish
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet tool install -g dotnet-ef --version 5.0.11 && \
    dotnet publish "CityLibrary.API/CityLibrary.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
WORKDIR /app/publish
ENTRYPOINT ["dotnet", "CityLibrary.API.dll"]