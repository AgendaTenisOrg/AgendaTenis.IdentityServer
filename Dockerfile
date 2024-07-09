FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ports/AgendaTenis.IdentityServer.WebApi/AgendaTenis.IdentityServer.WebApi.csproj", "src/ports/AgendaTenis.IdentityServer.WebApi/"]
COPY ["src/core/AgendaTenis.IdentityServer.Core/AgendaTenis.IdentityServer.Core.csproj", "src/core/AgendaTenis.IdentityServer.Core/"]
RUN dotnet restore "./src/ports/AgendaTenis.IdentityServer.WebApi/AgendaTenis.IdentityServer.WebApi.csproj"
COPY . .
WORKDIR "/src/src/ports/AgendaTenis.IdentityServer.WebApi"
RUN dotnet build "./AgendaTenis.IdentityServer.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AgendaTenis.IdentityServer.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AgendaTenis.IdentityServer.WebApi.dll"]