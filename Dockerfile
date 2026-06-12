FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy project file and restore
COPY *.csproj ./
RUN dotnet restore

# Copy everything and build
COPY . ./
RUN dotnet build -c Release --no-restore

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/bin/Release/net8.0 ./

# Run the app
ENTRYPOINT ["dotnet", "lcm.dll"]