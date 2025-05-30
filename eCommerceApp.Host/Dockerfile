# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY eCommerceApp.Application/*.csproj ./eCommerceApp.Application/
COPY eCommerceApp.Domain/*.csproj ./eCommerceApp.Domain/
COPY eCommerceApp.Infrastructure/*.csproj ./eCommerceApp.Infrastructure/
COPY eCommerceApp.Host/*.csproj ./eCommerceApp.Host/
RUN dotnet restore

# Copy everything else and build
COPY . .
WORKDIR /app/eCommerceApp.Host
RUN dotnet publish -c Release -o out

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/eCommerceApp.Host/out ./
ENTRYPOINT ["dotnet", "eCommerceApp.Host.dll"]

