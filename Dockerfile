FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /build
COPY Accounting.csproj Accounting.csproj
RUN dotnet restore
COPY . .
RUN dotnet test
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app

COPY --from=build /app .

ENV ASPNETCORE_URLS=http://+:8000

RUN useradd --uid $(shuf -i 2000-65000 -n 1) app
USER app

ENTRYPOINT ["dotnet", "Accounting.dll", "--hostBuilder:reloadConfigOnChange=false"]
