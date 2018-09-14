#!/bin/bash
rm -rf database/sql/data/err.log
docker-compose down
docker-compose build

docker-compose up
