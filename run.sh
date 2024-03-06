#!/usr/bin/env bash

cp -nv ./docker/conf/.env.example ./docker/conf/.env

ARGS='-f compose.yml --env-file ./docker/conf/.env'

docker compose $ARGS restart
docker compose $ARGS up -d
docker compose $ARGS ps -a
