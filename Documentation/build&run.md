# Overview

## Prerequirements
*   docker
*   dotnet core

## Building application
Use build.sh to build the whole application and create docker image

## Running application
Use run.sh to run mssql container and application container.
use run-application-container.sh to run only application.

Use go.sh to buld and run application.

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
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Test123$' \
    -p 1433:1433 -d \
    --volumes-from linuxsqldata \
    microsoft/mssql-server-linux
```
Now you can start and stop your container without losing your data. Additionally you can docker cp a backup or the *.mdf and *.ldf files into this volume.

docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Test123$' -p 1433:1433 -d microsoft/mssql-server-linux
