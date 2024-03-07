#!/usr/bin/env bash

ARGS='-f compose.yml --env-file ./docker/conf/.env'

export HOST_UID=$(id -u)
export HOST_GID=$(id -g)

docker compose $ARGS exec app fish -c 'php artisan migrate:fresh --seed'
