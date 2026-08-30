# Etapa 1: Compilación y publicación
FROM ://microsoft.com AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

# Etapa 2: Entorno de ejecución
FROM ://microsoft.com
WORKDIR /app
COPY --from=build-env /app/out .

ENV ASPNETCORE_URLS=http://+:10000
ENV DOTNET_USE_POLLING_FILE_WATCHER=1
ENV ASPNETCORE_HOSTINGSTARTUPASSEMBLIES=
EXPOSE 10000

USER root
RUN chmod -R 777 /app

ENTRYPOINT ["dotnet", "Evaluacion 2026-2.dll"]
 
