#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["eCommerce.Api/eCommerce.Api.csproj", "eCommerce.Api/"]
COPY ["eCommerceApp.Application/eCommerceApp.Application.csproj", "eCommerceApp.Application/"]
COPY ["eCommerceApp.Domain/eCommerceApp.Domain.csproj", "eCommerceApp.Domain/"]
COPY ["eCommerceApp.Utilities/eCommerceApp.Utilities.csproj", "eCommerceApp.Utilities/"]
COPY ["eCommerceApp.Identity/eCommerceApp.Identity.csproj", "eCommerceApp.Identity/"]
COPY ["eCommerceApp.Infrastructure/eCommerceApp.Infrastructure.csproj", "eCommerceApp.Infrastructure/"]
COPY ["eCommerceApp.Persistence/eCommerceApp.Persistence.csproj", "eCommerceApp.Persistence/"]
RUN dotnet restore "eCommerce.Api/eCommerce.Api.csproj"
COPY . .
WORKDIR "/src/eCommerce.Api"
RUN dotnet build "eCommerce.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eCommerce.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eCommerce.Api.dll"]