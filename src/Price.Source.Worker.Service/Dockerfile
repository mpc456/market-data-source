#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Price.Source.Worker.Service/Price.Source.Worker.Service.csproj", "src/Price.Source.Worker.Service/"]
RUN dotnet restore "src/Price.Source.Worker.Service/Price.Source.Worker.Service.csproj"
COPY . .
WORKDIR "/src/src/Price.Source.Worker.Service"
RUN dotnet build "Price.Source.Worker.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Price.Source.Worker.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Price.Source.Worker.Service.dll"]