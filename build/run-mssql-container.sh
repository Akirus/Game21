#!/bin/bash          

source env.sh

echo "Executing docker command:
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Test123$' \
    -p 1433:1433 -d \
	--volumes-from linuxsqldata \
	--name $MSSQL_CONTAINER_NAME \
    microsoft/mssql-server-linux"

docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Test123$' \
    -p 1433:1433 -d \
	--volumes-from linuxsqldata \
	--name $MSSQL_CONTAINER_NAME \
    microsoft/mssql-server-linux
