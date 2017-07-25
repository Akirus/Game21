#!/bin/bash          

export APP_DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"
export BUILD_SRC_DIR=$APP_DIR/../Game21
export BUILD_DEST_DIR=$APP_DIR/dest

export MSSQL_CONTAINER_NAME="mssql"
export GAME21_CONTAINER_NAME="game21"

export CONTAINERS_NETWORK="game12net"
