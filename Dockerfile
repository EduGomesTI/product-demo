FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

#Copiar csproj e restaurar dependencias
COPY ["Product.API/Product.API.csproj", "Product.API/"]
COPY ["Product.CrossCutting/Product.CrossCutting.csproj", "Product.CrossCutting/"]
COPY ["Product.Domain/Product.Domain.csproj", "Product.Domain/"]
COPY ["Product.Data/Product.Data.csproj", "Product.Data/"]
COPY ["Product.Application/Product.Application.csproj", "Product.Application/"]
RUN dotnet restore "Product.API/Product.API.csproj"

#Build da aplicacao
COPY . .
RUN dotnet publish /src/Product.API/Product.API.csproj -c Release -o out

#Build da Imagem
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build src/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "Product.API.dll"]