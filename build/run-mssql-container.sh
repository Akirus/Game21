#!/bin/bash          

source env.sh

docker rm $MSSQL_CONTAINER_NAME

docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Test123$' \
    -p 1433:1433 -d \
	--volumes-from linuxsqldata \
	--net $CONTAINERS_NETWORK \
	--name $MSSQL_CONTAINER_NAME \
    microsoft/mssql-server-linux
