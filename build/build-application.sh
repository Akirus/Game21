#!/bin/bash          

source env.sh

cd $BUILD_SRC_DIR

dotnet publish -o $BUILD_DEST_DIR
