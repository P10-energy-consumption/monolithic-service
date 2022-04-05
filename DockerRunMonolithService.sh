#!/bin/bash
docker build -t petstore-monolith .

docker run --rm --add-host=host.docker.internal:host-gateway -p 8000:80 petstore-monolith
wait
