#!/usr/bin/env bash

ARGS='-f compose.yml --env-file ./AirlinesAPI/.env'

docker compose $ARGS exec app fish -c 'php artisan migrate:fresh --seed'
