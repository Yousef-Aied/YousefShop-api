# Use the official .NET 8.0 SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj files and restore as separate layers
COPY *.sln .
COPY eCommerceApp.Application/*.csproj ./eCommerceApp.Application/
COPY eCommerceApp.Domain/*.csproj ./eCommerceApp.Domain/
COPY eCommerceApp.Infrastructure/*.csproj ./eCommerceApp.Infrastructure/
COPY eCommerceApp.Host/*.csproj ./eCommerceApp.Host/
RUN dotnet restore

# Copy the rest of the code and build the app
COPY . .
WORKDIR /app/eCommerceApp.Host
RUN dotnet publish -c Release -o out

# Use the official ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/eCommerceApp.Host/out .
ENTRYPOINT ["dotnet", "eCommerceApp.Host.dll"]
