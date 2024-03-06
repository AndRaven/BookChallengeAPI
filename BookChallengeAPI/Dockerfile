FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8089
EXPOSE 7049

ENV ASPNETCORE_URLS=http://+:8089,https://+:7049

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["BookChallengeAPI/BookChallengeAPI.csproj", "BookChallengeAPI/"]
COPY ["BookChallenge.Test/BookChallenge.Test.csproj", "BookChallenge.Test/"]
RUN dotnet restore "BookChallengeAPI/BookChallengeAPI.csproj"
COPY . .
WORKDIR "/src/BookChallengeAPI"
RUN dotnet build "BookChallengeAPI.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "BookChallengeAPI.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookChallengeAPI.dll"]
