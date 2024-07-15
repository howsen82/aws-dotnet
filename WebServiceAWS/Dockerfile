FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ENV ASPNETCORE_URLS=http://+:8080

WORKDIR /src
COPY ["WebServiceAWS.csproj", "./"]
RUN dotnet restore "WebServiceAWS.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "WebServiceAWS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebServiceAWS.csproj" -c Release -o /app/publish --self-contained false --runtime linux-x64

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebServiceAWS.dll"]