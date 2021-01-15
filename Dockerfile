FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["InterestRate/InterestRate.csproj", "InterestRate/"]
COPY ["InterestRate.API/InterestRate.API.csproj", "InterestRate.API/"]
RUN dotnet restore "InterestRate.API/InterestRate.API.csproj"
RUN dotnet restore "InterestRate/InterestRate.csproj"

COPY . .
WORKDIR "/src/InterestRate.API"
RUN dotnet build "InterestRate.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InterestRate.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InterestRate.API.dll"]
