[![Github release](https://img.shields.io/github/v/release/rolfwessels/IMapToSlack)](https://github.com/rolfwessels/IMapToSlack/releases)
[![Dockerhub Status](https://img.shields.io/badge/dockerhub-ok-blue.svg)](https://hub.docker.com/r/rolfwessels/IMapToSlack/tags)
[![Dockerhub Version](https://img.shields.io/docker/v/rolfwessels/IMapToSlack?sort=semver)](https://hub.docker.com/r/rolfwessels/IMapToSlack/tags)
[![GitHub](https://img.shields.io/github/license/rolfwessels/IMapToSlack)](https://github.com/rolfwessels/IMapToSlack/licence.md)

<img src="./docs/logo.png" style=" margin-left: auto;margin-right: auto;display: block;"
     alt="I map to slack">


# I map to slack


This makes i map to slack happen

## Getting started

Open the docker environment to do all development and deployment

```bash
# bring up dev environment
make build up
# test the project
make test
# build the project ready for publish
make publish
```

## Available make commands

### Commands outside the container

- `make up` : brings up the container & attach to the default container
- `make down` : stops the container
- `make build` : builds the container

### Commands to run inside the container

- `make config` : Used to create aws config files
- `make init` : Initialize terraform locally
- `make plan` : Run terraform plan
- `make apply` : Run terraform Apply

## Research

- <https://opensource.com/article/18/8/what-how-makefile> What is a Makefile and how does it work?
