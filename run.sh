#!/usr/bin/env bash

ARGS='-f compose.yml --env-file ./docker/conf/.env'

docker compose $ARGS restart
docker compose $ARGS up -d
docker compose $ARGS ps -a
