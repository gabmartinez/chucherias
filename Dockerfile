FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app

ARG AppId
ENV AppId=$AppId

ARG AppSecret
ENV AppSecret=$AppSecret

COPY --from=build-env /app/out .

RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh
# ENTRYPOINT ["dotnet", "konoha.dll"]