FROM microsoft/aspnetcore:latest
WORKDIR /app
COPY ./publish .

ENV ASPNETCORE_URLS http://+:80
EXPOSE 80 

ENTRYPOINT ["dotnet", "demo.dll"]