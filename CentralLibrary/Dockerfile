ARG ASPNET_VERSION=5.0
ARG SDK_VERSION=5.0

FROM mcr.microsoft.com/dotnet/aspnet:${ASPNET_VERSION} AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:${SDK_VERSION} AS build
WORKDIR /app
COPY . .

RUN dotnet restore "CentralLibrary.Domain/CentralLibrary.Domain.csproj" && \
    dotnet build "CentralLibrary.Domain/CentralLibrary.Domain.csproj" -c Release

RUN dotnet restore "CentralLibrary.Persistence/CentralLibrary.Persistence.csproj" && \
    dotnet build "CentralLibrary.Persistence/CentralLibrary.Persistence.csproj" -c Release

RUN dotnet restore "CentralLibrary.API/CentralLibrary.API.csproj" && \
    dotnet build "CentralLibrary.API/CentralLibrary.API.csproj" -c Release

FROM build AS publish
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet tool install -g dotnet-ef --version 5.0.11 && \
    dotnet publish "CentralLibrary.API/CentralLibrary.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
WORKDIR /app/publish
ENTRYPOINT ["dotnet", "CentralLibrary.API.dll"]