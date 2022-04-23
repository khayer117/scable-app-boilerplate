#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Sab.Authentication.Api/Sab.Authentication.Api.csproj", "Sab.Authentication.Api/"]
RUN dotnet restore "Sab.Authentication.Api/Sab.Authentication.Api.csproj"
COPY . .
WORKDIR "/src/Sab.Authentication.Api"
RUN dotnet build "Sab.Authentication.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sab.Authentication.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sab.Authentication.Api.dll"]