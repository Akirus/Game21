#!/bin/bash          

source env.sh

./run-mssql-container.sh
./run-application-container.sh

