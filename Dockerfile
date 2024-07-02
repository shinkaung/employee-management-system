# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Install EF Core tools
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

# Final stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app

# Install EF Core tools in the final image as well
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

COPY --from=build /app/publish .
COPY --from=build /src /src

# Set the entry point for the application
ENV ASPNETCORE_URLS=http://*:80
ENTRYPOINT ["dotnet", "EMS.dll"]
