#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Interview1.API/Interview1.API.csproj", "Interview1.API/"]
RUN dotnet restore "Interview1.API/Interview1.API.csproj"
COPY . .
WORKDIR "/src/Interview1.API"
RUN dotnet build "Interview1.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Interview1.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Interview1.API.dll"]