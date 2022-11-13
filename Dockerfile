FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
RUN git clone https://github.com/DavidZhiXing/fetch.git
WORKDIR /fetch
RUN dotnet publish -c Release -o app
ENTRYPOINT ["app/fetch"]