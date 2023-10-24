# See https://aka.ms/containerfastmode for more info on Docker and Visual Studio integration.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Ijustkeeptryingiguess", "Ijustkeeptryingiguess/"]
RUN ls /src
WORKDIR "/src/Ijustkeeptryingiguess/"
RUN ls "/src/Ijustkeeptryingiguess/"
RUN dotnet restore 
RUN dotnet build -c Release --no-restore

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ijustkeeptryingiguess.dll"]
