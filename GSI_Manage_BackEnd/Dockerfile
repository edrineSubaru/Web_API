# Use the official .NET 8 SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the .csproj file and restore dependencies
COPY GSI_Manage_BackEnd/GSI_Manage_BackEnd.csproj GSI_Manage_BackEnd/
RUN dotnet restore GSI_Manage_BackEnd/GSI_Manage_BackEnd.csproj

# Copy the rest of the source code
COPY . .

# Build the application
RUN dotnet build GSI_Manage_BackEnd/GSI_Manage_BackEnd.csproj -c Release -o /app/build

# Publish the application
RUN dotnet publish GSI_Manage_BackEnd/GSI_Manage_BackEnd.csproj -c Release -o /app/publish

# Use the official .NET 8 runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose the port the app runs on
EXPOSE 80

# Set the entry point
ENTRYPOINT ["dotnet", "GSI_Manage_BackEnd.dll"]