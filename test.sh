#!/usr/bin/env bash

export HOST_UID=$(id -u)
export HOST_GID=$(id -g)

docker compose -f compose-api-test.yml down
docker compose -f compose-api-test.yml up -d
docker compose -f compose-api-test.yml logs -f api-tests
