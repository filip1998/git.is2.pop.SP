#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["REST.API.SP/REST.API.SP.csproj", "REST.API.SP/"]
RUN dotnet restore "REST.API.SP/REST.API.SP.csproj"
COPY . .
WORKDIR "/src/REST.API.SP"
RUN dotnet build "REST.API.SP.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "REST.API.SP.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "REST.API.SP.dll"]