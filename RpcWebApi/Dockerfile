#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 19020
EXPOSE 19021

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["RpcWebApi/RpcWebApi.csproj", "RpcWebApi/"]
COPY ["DataManage/DataManage.csproj", "DataManage/"]
RUN dotnet restore "RpcWebApi/RpcWebApi.csproj"
COPY . .
WORKDIR "/src/RpcWebApi"
RUN dotnet build "RpcWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RpcWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RpcWebApi.dll"]