#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Way2Commerce.API/Way2Commerce.API.csproj", "Way2Commerce.API/"]
RUN dotnet restore "Way2Commerce.API/Way2Commerce.API.csproj"
COPY . .
WORKDIR "/src/Way2Commerce.API"
RUN dotnet build "Way2Commerce.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Way2Commerce.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Way2Commerce.API.dll"]