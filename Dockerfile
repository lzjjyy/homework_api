#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
RUN apt-get update && apt-get install -y libgdiplus
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["homework_api/homework_api.csproj", "homework_api/"]
RUN dotnet nuget add source http://172.16.3.36:8081/repository/nuget-group-mdland-hosted/ -n nuget-group-mdland-hosted
RUN dotnet restore "homework_api/homework_api.csproj"
COPY . .
WORKDIR "/src/homework_api"
RUN dotnet build "homework_api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "homework_api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "homework_api.dll"]