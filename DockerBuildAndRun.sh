#!/bin/bash
docker build -t petstore-monolith .

docker run --rm --add-host=host.docker.internal:host-gateway -p 8080:8080 petstore-monolith
