# Buil alpine
FROM alpine:3.14 AS build

# Create build directory
WORKDIR /build

# Copy files to directory
COPY ./data /build/

# Descompando arquivos de simulacao
RUN unzip simulationInput_D.zip -d .

# Container C#
FROM mcr.microsoft.com/dotnet/sdk:9.0@sha256:3fcf6f1e809c0553f9feb222369f58749af314af6f063f389cbd2f913b4ad556

# Create app directory
WORKDIR /app

# Copy files to directory
COPY ./ /app/

# Copiando tudo para deploy
COPY --from=build ./build /app/data

# Iniciando bun e executando testes
RUN dotnet build && dotnet test

# Iniciando CLI
ENTRYPOINT ["sh","Bench.sh"]