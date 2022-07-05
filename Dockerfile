FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine

# Base Development Packages
RUN apk update \
  && apk upgrade \
  && apk add ca-certificates wget && update-ca-certificates \
  && apk add --no-cache --update \
  git \
  curl \
  wget \
  bash \
  make \
  rsync \
  nano \
  && git config --global --add safe.directory /i-map-to-slack



# Working Folder
WORKDIR /i-map-to-slack

COPY src/IMapToSlack.Cmd/*.csproj ./src/IMapToSlack.Cmd/
COPY src/IMapToSlack.Core/*.csproj ./src/IMapToSlack.Core/
COPY tests/IMapToSlack.Core.Tests/*.csproj ./tests/IMapToSlack.Core.Tests/
WORKDIR /i-map-to-slack/src/IMapToSlack.Cmd/
RUN dotnet restore

WORKDIR /i-map-to-slack
ENV PATH="/root/.dotnet/tools:${PATH}"
ENV TERM xterm-256color
RUN printf 'export PS1="\[\e[0;34;0;33m\][DCKR]\[\e[0m\] \\t \[\e[40;38;5;28m\][\w]\[\e[0m\] \$ "' >> ~/.bashrc
