FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["InterestRateAPI/InterestRate.csproj", "InterestRate/"]
COPY ["InterestRateAPI/InterestRateAPI.csproj", "InterestRateAPI/"]
RUN dotnet restore "InterestRateAPI\InterestRateAPI.csproj"
RUN dotnet restore "InterestRateAPI\InterestRate.csproj"

COPY . .
WORKDIR "/src/InterestRateAPI"
RUN dotnet build "InterestRateAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InterestRateAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InterestRateAPI.dll"]
