#!/bin/bash          

source env.sh

docker rm game21

docker run --name game21 -d -p 5000:5000 --net $CONTAINERS_NETWORK game21
