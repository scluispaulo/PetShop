FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /source

COPY *.sln .
COPY src/Application/ src/Application/
COPY src/Domain/ src/Domain/
COPY src/Infrastructure/ src/Infrastructure/
COPY src/Service/ src/Service/
COPY src/Tests/UnitTests/*.csproj src/Tests/UnitTests/
RUN dotnet build -c release

FROM build AS publish
RUN dotnet publish -c release --no-build -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Application.dll"]