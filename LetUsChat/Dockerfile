FROM microsoft/aspnetcore:2.0-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 57688
EXPOSE 44342

FROM microsoft/aspnetcore-build:2.0-nanoserver-1709 AS build
WORKDIR /src
COPY LetUsChat/LetUsChat.csproj LetUsChat/
RUN dotnet restore LetUsChat/LetUsChat.csproj
COPY . .
WORKDIR /src/LetUsChat
RUN dotnet build LetUsChat.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish LetUsChat.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LetUsChat.dll"]
