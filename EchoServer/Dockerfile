FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./EchoServer/EchoServer.fsproj"
RUN dotnet build "./EchoServer/EchoServer.fsproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "./EchoServer/EchoServer.fsproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EchoServer.dll"]