FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Analytics.Presentation/Analytics.Presentation.csproj", "Analytics.Presentation/"]
COPY ["Analytics.DAL/Analytics.DAL.csproj", "Analytics.DAL/"]
COPY ["Analytics.BLL/Analytics.BLL.csproj", "Analytics.BLL/"]
RUN dotnet restore "Analytics.Presentation/Analytics.Presentation.csproj"
COPY . .
WORKDIR "/src/Analytics.Presentation"
RUN dotnet build "Analytics.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Analytics.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Analytics.Presentation.dll"]
