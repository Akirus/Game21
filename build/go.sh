#!/bin/bash          

./build.sh

./stop-application-container.sh
./run-application-container.sh