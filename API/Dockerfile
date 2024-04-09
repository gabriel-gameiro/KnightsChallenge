FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app 
#
# Traz a solution e os projetos
COPY *.sln .
COPY ./KnightsChallenge.API/*.csproj ./KnightsChallenge.API/
COPY ./KnightsChallenge.Core/*.csproj ./KnightsChallenge.Core/
#
RUN dotnet restore 
#
# Traz o restante dos arquivos dos projetos
WORKDIR /app 
COPY KnightsChallenge.API/. ./KnightsChallenge.API/
COPY KnightsChallenge.Core/. ./KnightsChallenge.Core/
# Builda
WORKDIR /app/KnightsChallenge.API
RUN dotnet publish -c Release -o out 

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app 

COPY --from=build /app/KnightsChallenge.API/out ./
EXPOSE 8081
ENTRYPOINT ["dotnet", "KnightsChallenge.API.dll"]