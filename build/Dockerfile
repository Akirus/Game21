FROM microsoft/aspnetcore
WORKDIR /app
COPY dest/ .
ENV ASPNETCORE_URLS http://+:5000
ENTRYPOINT ["dotnet", "Game21.dll"]

