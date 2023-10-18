# Use the official .NET Core SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build


# Set the working directory to /app
WORKDIR /app

# Copy the .csproj file to the container
COPY *.sln .
COPY  ./Simple.Api/*.csproj ./Simple.Api/
COPY  ./Simple.Api.Test/*.csproj ./Simple.Api.Test/

# Restore the NuGet packages
RUN dotnet restore

# Copy the rest of the application code to the container
COPY . ./

# Build
RUN dotnet build


# test
#FROM build AS testrunner
#WORKDIR "/app/Simple.Api.Test"
#CMD ["dotnet", "test"]
#RUN dotnet test


# Build the application
FROM build AS publish
WORKDIR "/app/Simple.Api"
RUN dotnet publish -c Release -o out

# Use the official .NET Core runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:7.0

# Set the working directory to /app
WORKDIR /app

# Copy the published output from the build environment to the container
COPY --from=publish /app/Simple.Api/out .

# Expose port 80 for the application
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "Simple.Api.dll"]
