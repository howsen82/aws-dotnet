FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["BlazorApp.csproj", "./"]
RUN dotnet restore "BlazorApp.csproj"

COPY . .
RUN dotnet publish "BlazorApp.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

EXPOSE 80
EXPOSE 443

WORKDIR /app
COPY --from=build /app/publish
ENTRYPOINT ["dotnet", "BlazorApp.dll"]