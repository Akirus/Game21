#!/bin/bash          

docker rm game21

docker run --name game21 -d -p 5000:5000 game21
