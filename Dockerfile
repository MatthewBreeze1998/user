FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Cloud-System-dev-ops/Users.csproj", "Cloud-System-dev-ops/"]
RUN dotnet restore "Cloud-System-dev-ops/Users.csproj"
COPY . .
WORKDIR "/src/Cloud-System-dev-ops"
RUN dotnet build "Users.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Users.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Users.dll"]