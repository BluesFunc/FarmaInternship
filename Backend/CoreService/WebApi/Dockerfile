FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Core.Domain/Core.Domain.csproj", "Core.Domain/"]
RUN dotnet restore "Core.Domain/Core.Domain.csproj"
COPY ["Core.Application/Core.Application.csproj", "Core.Application/"]
RUN dotnet restore "Core.Application/Core.Application.csproj"
COPY ["Core.Infrastructure/Core.Infrastructure.csproj", "Core.Infrastructure/"]
RUN dotnet restore "Core.Infrastructure/Core.Infrastructure.csproj"
COPY ["WebApi/WebApi.csproj", "WebApi/"]
RUN dotnet restore "WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/WebApi"
RUN dotnet build "WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]
