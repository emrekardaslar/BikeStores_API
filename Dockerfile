# Use the official .NET Core SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy solution and project files
COPY *.sln ./
COPY src/BikeStores.Application/BikeStores.Application.csproj src/BikeStores.Application/
COPY src/BikeStores.Core/BikeStores.Core.csproj src/BikeStores.Core/
COPY src/BikeStores.Infrastructure/BikeStores.Infrastructure.csproj src/BikeStores.Infrastructure/
COPY src/BikeStores.API/BikeStores.API.csproj src/BikeStores.API/
COPY tests/BikeStores.Core.Tests/BikeStores.Core.Tests.csproj tests/BikeStores.Core.Tests/
COPY tests/BikeStores.Application.Tests/BikeStores.Application.Tests.csproj tests/BikeStores.Application.Tests/
COPY tests/BikeStores.Infrastructure.Tests/BikeStores.Infrastructure.Tests.csproj tests/BikeStores.Infrastructure.Tests/
COPY tests/BikeStores.API.Tests/BikeStores.API.Tests.csproj tests/BikeStores.API.Tests/

# Restore dependencies
RUN dotnet restore

# Copy everything else and build
COPY . ./
WORKDIR /app/src/BikeStores.API
RUN dotnet publish -c Release -o out

# Use the official ASP.NET Core runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/src/BikeStores.API/out .

# Set environment variables (if necessary)
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

# Entry point for the application
ENTRYPOINT ["dotnet", "BikeStores.API.dll"]
