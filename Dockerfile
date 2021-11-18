FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Bootstrapper", "Bootstrapper"]
COPY ["src/Modules", "Modules"]
COPY ["src/Shared", "Shared"]
RUN dotnet restore "Bootstrapper/ModularRestaurant.Bootstrapper/ModularRestaurant.Bootstrapper.csproj"
COPY . .
WORKDIR "/src/Bootstrapper/ModularRestaurant.Bootstrapper"
RUN dotnet build "ModularRestaurant.Bootstrapper.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ModularRestaurant.Bootstrapper.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ModularRestaurant.Bootstrapper.dll"]
