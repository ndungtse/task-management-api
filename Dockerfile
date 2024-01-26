FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
# Install the .NET Core runtime
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["task-management-api.csproj", "./"]
RUN dotnet restore "task-management-api.csproj"
COPY . .
WORKDIR "/src/"
# Add EF Core CLI tools and migrate the database
#RUN dotnet tool install --global dotnet-ef
#ENV PATH="${PATH}:/root/.dotnet/tools"
#RUN dotnet ef database update
# Build the app
RUN dotnet build "task-management-api.csproj" -c $BUILD_CONFIGURATION -o /app/build
# Publish the app
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "task-management-api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
# Run the app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "task-management-api.dll"]
