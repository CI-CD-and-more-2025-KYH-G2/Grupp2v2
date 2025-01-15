FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env

WORKDIR /app

COPY ./bin/Release/net9.0/ .

CMD ["dotnet", "docker-intro-gh.dll"]
