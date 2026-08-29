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
EXPOSE 10000

ENTRYPOINT ["dotnet", "Evaluacion 2026-2.dll"]
