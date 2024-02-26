#!/usr/bin/env bash

ARGS='-f compose-api-test.yml --env-file ./AirlinesAPI/.env'

export HOST_UID=$(id -u)
export HOST_GID=$(id -g)

docker compose $ARGS down
docker compose $ARGS up -d
docker compose $ARGS logs -f api-tests
docker compose $ARGS down
