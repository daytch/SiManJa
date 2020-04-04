FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["src/uangsaku.UI.Web/uangsaku.UI.Web.csproj", "src/uangsaku.UI.Web/"]
RUN dotnet restore "src/uangsaku.UI.Web/uangsaku.UI.Web.csproj"
COPY . .
WORKDIR "/src/src/uangsaku.UI.Web"
RUN dotnet build "uangsaku.UI.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "uangsaku.UI.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "uangsaku.UI.Web.dll"]
