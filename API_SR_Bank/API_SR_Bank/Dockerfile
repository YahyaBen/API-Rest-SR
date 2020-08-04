#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["API_SR_Bank/API_SR_Bank.csproj", "API_SR_Bank/"]
RUN dotnet restore "API_SR_Bank/API_SR_Bank.csproj"
COPY . .
WORKDIR "/src/API_SR_Bank"
RUN dotnet build "API_SR_Bank.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API_SR_Bank.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API_SR_Bank.dll"]

###################### Docker Commandes ########################
# Docker build -t api_sr_bank:v.1.0.0  . #t for tag
# Docker images #lister les images Docker
# Docker run -it --rm -p 8080:80 API_SR_BANK:v.1.0.0