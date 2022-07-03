FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 5091

ENV ASPNETCORE_URLS=http://*:5091
ENV ConnectionStrings:DefaultConnection=Host=postgres;Port=5432;Database=desafio;Username=postgres;Password=postgres;
ENV ASPNETCORE_ENVIRONMENT=Development

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["desafio.csproj", "./"]
RUN dotnet restore "desafio.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "desafio.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "desafio.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "desafio.dll"]