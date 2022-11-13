FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /fetch
COPY . .
RUN dotnet publish -c Release -o app
ENTRYPOINT ["app/fetch"]