FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /

COPY *.sln .

COPY Walmad.WebAPI/Walmad.WebAPI.csproj Walmad.WebAPI/
COPY Walmad.Controller/Walmad.Controller.csproj Walmad.Controller/
COPY Walmad.Service/Walmad.Service.csproj Walmad.Service/
COPY Walmad.Core/Walmad.Core.csproj Walmad.Core/
COPY Walmad.Test/Walmad.Test.csproj Walmad.Test/

RUN dotnet restore

COPY Walmad.Framework/ Walmad.Framework/
COPY Walmad.Controller/ Walmad.Controller/
COPY Walmad.Service/ Walmad.Service/
COPY Walmad.Core/ Walmad.Core/
COPY Walmad.Test/ Walmad.Test/

WORKDIR /Walmad.WebAPI
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /
COPY --from=build /publish .
EXPOSE 8080
ENTRYPOINT [ "dotnet", "Walmad.WebAPI.dll" ]