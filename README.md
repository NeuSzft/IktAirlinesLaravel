# :airplane: Airlines Management Project

### Table of Contents
- [Overview](#overview)
- [Database API](#database-api)
- [Web Interface](#web-interface)
- [Desktop Application](#desktop-application)
- [Getting started](#getting-started)
- [Testing](#testing)

## Overview

This project contains an API for managing a MySql database, a web interface for seeing available flights and their prices, and a desktop application that provides a graphical interface for managing the database trough the API.

## Database API

The API is made using the [Laravel](https://laravel.com/) php framework.
Endpoint documentation is served the webserver under `/docs`.

## Web Interface

[User manual](./AirlinesWeb/README.md)

## Desktop Application

The desktop application's purpose is to make adding, updating and removing entries from the database a simple task.

It is made using the [Windows Presentation Foundation](https://github.com/dotnet/wpf) framework and is only available for windows machines.

Check the [user manual](./docs/desktop-app-manual.md) for help.

## Getting started

To run the database and web services, all you need is [Docker Compose](https://docs.docker.com/compose/) and [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) for the desktop application.

To start the services run the [run.sh](./run.sh) shell script.

You need to create a `.env` file inside the [/docker/conf](./docker/conf) directory. Use the [example](./docker/conf/.env.example) file as a template.

By default the these local ports are used by the services:
- 5000 - Database API
- 8000 - phpMyAdmin
- 8080 - Web server

### Setting up Laravel
You need to run a few commands inside the `app` container after it has started, to set up Laravel for the first time.
You can enter the container by running the `docker compose exec app fish` command.
> You will see multiple warnings about environment variables not being set, but these can be safely ignored.

1. Generate a key for Laravel by running `php artisan key:generate`.
2. Run the migrations and database seeders with the `php artisan migrate:fresh --seed` command.
3. Simply exit the container by running `exit`.

## Testing

| Test | Compose File | Shell Script | Files | Latest Results |
| --- | --- | --- | --- | --- |
| API tests | [compose.test-api.yml](./testing/api/compose.yml) | [test.sh](./test.sh) | [PostTests.cs](./AirlinesAPI.Tests/PostTests.cs)<br>[GetTests.cs](./AirlinesAPI.Tests/GetTests.cs)<br>[PutTests.cs](./AirlinesAPI.Tests/PutTests.cs)<br>[DeleteTests.cs](./AirlinesAPI.Tests/DeleteTests.cs) | [view](./docs/api-test-results.md) |
| Selenium tests | [compose.test-web.yml](./compose.test-web.yml) | [selenium.sh](./selenium.sh) | [SeleniumTests.cs](./AirlinesWeb.Tests/SeleniumTests.cs) | [view](./AirlinesWebTest/README.md) |
