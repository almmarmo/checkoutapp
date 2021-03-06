FROM microsoft/aspnetcore-build:lts
COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
EXPOSE 80/tcp
EXPOSE 1433/tcp
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh