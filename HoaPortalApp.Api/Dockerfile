#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["HoaPortalApp.Api/HoaPortalApp.Api.csproj", "HoaPortalApp.Api/"]
COPY ["HoaPortalApp.Identity/HoaPortalApp.Identity.csproj", "HoaPortalApp.Identity/"]
COPY ["HoaPortalApp.Application/HoaPortalApp.Application.csproj", "HoaPortalApp.Application/"]
COPY ["HoaPortalApp.Domain/HoaPortalApp.Domain.csproj", "HoaPortalApp.Domain/"]
COPY ["HoaPortalApp.Persistence/HoaPortalApp.Persistence.csproj", "HoaPortalApp.Persistence/"]
RUN dotnet restore "./HoaPortalApp.Api/./HoaPortalApp.Api.csproj"
COPY . .
WORKDIR "/src/HoaPortalApp.Api"
RUN dotnet build "./HoaPortalApp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HoaPortalApp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HoaPortalApp.Api.dll"]