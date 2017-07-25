# Overview

## Prerequirements
*   docker
*   dotnet core

## Build flow:
1. dotnet restore (from $src)
2. dotnet build (from $build0
3. dotnet publish -> $artifact1
4. create a docker image from $artifact1 -> $artifact2

## Run flow
1. run mssql from docker.
2. run $artifact2 docker image.

## Issues 

### Issue 1
how to pes

docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Test123$' -p 1433:1433 -d microsoft/mssql-server-linux