# :airplane: Airlines Management Project

### Table of Contents
- [Overview](#overview)
- [Database API](#database-api)
- [Web Interface](#web-interface)
- [Desktop Application](#desktop-application)
- [Getting started](#getting-started)
- [Testing](#testing)

## Overview

This project contains an API for managing a PostgreSQL database, a web interface for seeing available flights and their prices, and a desktop application that provides a graphical interface for managing the database trough the API.

## Database API

The API is made using [APS.NET Core](https://github.com/dotnet/aspnetcore) and it's [Minimal APIs](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/overview?view=aspnetcore-8.0) approach.

List of available [endpoints](./AirportManagement/docs/endpoints.md).

## Web Interface

[User manual](./AirportWeb/README.md)

## Desktop Application

The desktop application's purpose is to make adding, updating and removing entries from the database a simple task.

It is made using the [Windows Presentation Foundation](https://github.com/dotnet/wpf) framework and is only available for windows machines.

Check the [user manual](./AirportManagement/docs/desktop-app-manual.md) for help.

## Getting started

The database, API and web server can be run using [docker compose](https://github.com/docker/compose) and the [compose.yml](./compose.yml) compose file.
Run `docker compose up` command to launch the containers.
> It can also be done by running the [run.sh](./run.sh) shell script.

Local ports used by the services:
- 8000 - phpMyAdmin
- 5000 - Database API
- 8080 - Web server

## Testing

The tests can be run using [docker compose](https://github.com/docker/compose) and the appropriate compose file. Hoverver it is advised to use the shell scripts instead.

| Test | Compose File | Shell Script | Files | Latest Results |
| --- | --- | --- | --- | --- |
| API tests | [compose.test-api.yml](./compose.test-api.yml) | [test-api.sh](./test-api.sh) | [ApiTests](./AirlinesAPI.Tests) | [view](./AirportManagement/api-test-results.md) |
| Selenium tests | [compose.test-web.yml](./compose.test-web.yml) | [test-web.sh](./test-web.sh) | [SeleniumTests.cs](./AirportWeb.Tests/SeleniumTests.cs) | [view](./AirportWebTest/README.md) |
