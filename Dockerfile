# Use the official .NET Core SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy solution and project files
COPY *.sln ./
COPY src/ArcTemplate.Application/ArcTemplate.Application.csproj src/ArcTemplate.Application/
COPY src/ArcTemplate.Core/ArcTemplate.Core.csproj src/ArcTemplate.Core/
COPY src/ArcTemplate.Infrastructure/ArcTemplate.Infrastructure.csproj src/ArcTemplate.Infrastructure/
COPY src/ArcTemplate.WebApi/ArcTemplate.WebApi.csproj src/ArcTemplate.WebApi/
COPY tests/ArcTemplate.Core.Tests/ArcTemplate.Core.Tests.csproj tests/ArcTemplate.Core.Tests/
COPY tests/ArcTemplate.Application.Tests/ArcTemplate.Application.Tests.csproj tests/ArcTemplate.Application.Tests/
COPY tests/ArcTemplate.Infrastructure.Tests/ArcTemplate.Infrastructure.Tests.csproj tests/ArcTemplate.Infrastructure.Tests/
COPY tests/ArcTemplate.WebApi.Tests/ArcTemplate.WebApi.Tests.csproj tests/ArcTemplate.WebApi.Tests/

# Restore dependencies
RUN dotnet restore

# Copy everything else and build
COPY . ./
WORKDIR /app/src/ArcTemplate.WebApi
RUN dotnet publish -c Release -o out

# Use the official ASP.NET Core runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/src/ArcTemplate.WebApi/out .

# Set environment variables (if necessary)
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

# Entry point for the application
ENTRYPOINT ["dotnet", "ArcTemplate.WebApi.dll"]
