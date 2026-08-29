# Etapa 1: Compilación y publicación
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build-env
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out
# Etapa 2: Entorno de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build-env /app/out .
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

# PARCHE CRÍTICO PARA RENDER: Desactivar recarga automática de archivos
ENV DOTNET_USE_POLLING_FILE_WATCHER=1
ENV ASPNETCORE_HOSTINGSTARTUPASSEMBLIES=

ENTRYPOINT ["dotnet", "Evaluacion 2026-2.dll"]
