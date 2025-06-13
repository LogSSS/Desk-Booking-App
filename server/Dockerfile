# ---- Stage 1: Build ----
# Use the .NET 8 SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container
WORKDIR /src

# Copy the solution file and project files first to leverage Docker layer caching.
# The paths are now simpler because the Dockerfile is in the same directory.
COPY *.sln .
COPY API/*.csproj ./API/
COPY Core/*.csproj ./Core/
COPY DAL/*.csproj ./DAL/ 
COPY Shared/*.csproj ./Shared/

# Restore all NuGet packages for the solution
RUN dotnet restore

# Copy the rest of the source code for all projects
COPY . .

# Publish the API project for release. The output will be in /app/publish
# Note the simpler path to the project file.
RUN dotnet publish "API/API.csproj" -c Release -o /app/publish --no-restore

# ---- Stage 2: Final ----
# Use the smaller ASP.NET 8 runtime image for the final container
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Set the working directory
WORKDIR /app

# Copy the published output from the 'build' stage
COPY --from=build /app/publish .

# The .NET 8 base image listens on port 8080 by default for HTTP.
EXPOSE 5000

# Define the entry point for the container to run your API
ENTRYPOINT ["dotnet", "API.dll"]