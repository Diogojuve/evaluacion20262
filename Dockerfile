# Etapa 1: Compilación y publicación
FROM ://microsoft.com AS build-env
WORKDIR /app

# Copiar archivos de proyecto y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto del código y compilar la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa 2: Entorno de ejecución
FROM ://microsoft.com
WORKDIR /app
COPY --from=build-env /app/out .

# Configurar la variable de entorno para escuchar en el puerto de Render
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "Evaluacion 2026-2.dll"]
