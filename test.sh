#!/usr/bin/env bash

cp -nv ./docker/conf/.env.example ./docker/conf/.env

ARGS='-f compose-api-test.yml --env-file ./docker/conf/.env'

export HOST_UID=$(id -u)
export HOST_GID=$(id -g)

docker compose $ARGS up -d
docker compose $ARGS wait api-tests
docker compose $ARGS ps -a
docker compose $ARGS down
