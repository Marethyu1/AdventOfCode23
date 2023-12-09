FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AdventDebugger/AdventDebugger.csproj", "AdventDebugger/"]
RUN dotnet restore "AdventDebugger/AdventDebugger.csproj"
COPY . .
WORKDIR "/src/AdventDebugger"
RUN dotnet build "AdventDebugger.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdventDebugger.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdventDebugger.dll"]
