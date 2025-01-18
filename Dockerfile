FROM mcr.microsoft.com/dotnet/sdk:9.0@sha256:3fcf6f1e809c0553f9feb222369f58749af314af6f063f389cbd2f913b4ad556 AS build

# Create app directory
WORKDIR /app

# Copy files to directory
COPY ./ /app/

# Iniciando bun e executando testes
RUN dotnet build && dotnet test

# Iniciando CLI
ENTRYPOINT ["sh","Bench.sh"]