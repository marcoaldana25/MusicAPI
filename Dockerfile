#Get Asp.NET 8.0 runtime and set as base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# GET .NET 8.0 SDK and set as build
FROM mcr.microsoft.com/dotnet/sdk:8.0 as build

# Set working directory
WORKDIR /MusicAPI

#Expose ports 8080 for HTTP and 8081 for HTTPS
EXPOSE 8080
EXPOSE 8081

# Copy everything
COPY . ./

#Restore solution and dependencies
RUN dotnet restore

#Build & Publish application as a release configuration
RUN dotnet build ./MusicAPI.sln -c Release -o out

FROM build AS publish
RUN dotnet publish ./MusicAPI.sln -c Release -o out

#Build Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /MusicAPI
COPY --from=build /MusicAPI/out .

#Name of the dll for the application
ENTRYPOINT ["dotnet", "MusicAPI.dll"]