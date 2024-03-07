#!/usr/bin/env bash

ARGS='-f compose-selenium-test.yml --env-file ./docker/conf/.env'

export HOST_UID=$(id -u)
export HOST_GID=$(id -g)

docker compose $ARGS up -d
docker compose $ARGS wait selenium-tests
docker compose $ARGS ps -a
docker compose $ARGS stop
