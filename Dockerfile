FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY RPFramework/*.csproj ./RPFramework/
COPY TestsApi/*.csproj ./TestsApi/

# copy full solution over
COPY . .
RUN dotnet build

FROM build AS apitestrunner
WORKDIR /app/TestsApi
CMD ["dotnet", "test", "--logger:trx"]

# run the api tests
FROM build AS test
WORKDIR /app/TestsApi
RUN dotnet test --logger:trx