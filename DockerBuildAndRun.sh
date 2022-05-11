#!/bin/bash
docker build -t petstore-monolith .

docker run --rm --add-host=host.docker.internal:host-gateway --name petstore-monolith -p 8080:8080 petstore-monolith &
