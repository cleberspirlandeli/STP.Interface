#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["STP.Interface/STP.Interface.csproj", "STP.Interface/"]
RUN dotnet restore "STP.Interface/STP.Interface.csproj"
COPY . .
WORKDIR "/src/STP.Interface"
RUN dotnet build "STP.Interface.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "STP.Interface.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "STP.Interface.dll"]