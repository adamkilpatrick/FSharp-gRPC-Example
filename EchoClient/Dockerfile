FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./EchoClient/EchoClient.fsproj"
RUN dotnet build "./EchoClient/EchoClient.fsproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "./EchoClient/EchoClient.fsproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EchoClient.dll"]