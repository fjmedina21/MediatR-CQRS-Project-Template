FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM base AS build
ARG BUILD_CONFIGURATION=Release
COPY ["src/MyAppApi.Api/MyAppApi.Api.csproj", "src/MyAppApi.Api/"]
COPY ["src/MyAppApi.Domain/MyAppApi.Domain.csproj", "src/MyAppApi.Domain/"]
COPY ["src/MyAppApi.Infrastructure/MyAppApi.Infrastructure.csproj", "src/MyAppApi.Infrastructure/"]
COPY ["src/MyAppApi.Application/MyAppApi.Application.csproj", "src/MyAppApi.Application/"]
RUN dotnet restore "src/MyAppApi.Api/MyAppApi.Api.csproj"
COPY . .
WORKDIR "/src/MyAppApi.Api"
RUN dotnet build "./MyAppApi.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MyAppApi.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyAppApi.Api.dll"]


