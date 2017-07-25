# Overview

## Prerequirements
*   docker
*   dotnet core

## Build flow:
1. dotnet restore
2. dotnet build
3. dotnet publish -> $artifact1
4. create a docker image from $artifact1 -> $artifact2

## Run flow
1. run mssql from docker.
2. run $artifact2 docker image.

## Issues 

### Issue #1
how to persist data into docker container. 

You can create a persistent data container with the image itself.
First create the data container and with volume /var/opt/mssql:
```
docker create -v /var/opt/mssql --name linuxsqldata microsoft/mssql-server-linux
```

Then mount the volumes from this container:

```
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' \
    -p 1433:1433 -d \
    --volumes-from linuxsqldata \
    microsoft/mssql-server-linux
```
Now you can start and stop your container without losing your data. Additionally you can docker cp a backup or the *.mdf and *.ldf files into this volume.

docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Test123$' -p 1433:1433 -d microsoft/mssql-server-linux