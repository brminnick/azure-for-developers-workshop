FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine as base
WORKDIR /app

FROM microsoft/dotnet:2.2-sdk-alpine as build
WORKDIR /src
COPY hotelsweb.csproj .
RUN dotnet restore
COPY . .
WORKDIR /src
RUN dotnet build -c Release -o /app

FROM build as publish
RUN dotnet publish -c Release -o /app

FROM base as final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "hotelsweb.dll"]