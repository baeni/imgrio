# Overview

imgrio contains of three components

- postgreSQL database
- imgrio-api
- imgrio-vue

where the former two represent the backend and "imgrio-vue" the frontend.

For storing the UserFiles and additional information for imgrio, the PostgreSQL database comes in place. PostgreSQL was chosen to be able to work with the EntityFramework within the imgrio-api.<br>
The imgrio-api is necessary to handle HTTP-Requests which is basically how imgrio works and lives.<br>
imgrio-vue is the component giving the whole struct a pleasant face.


# How to setup?

## PostgreSQL database

First we need to create a place where UserFiles and additional information can be stored, so the imgrio-api can work properly.

To make the database accessible for the imgrio-api, we need to make a small configuration within the `pg_hba.conf` file (normally located at `/var/lib/pgsql/data/`). Simply add the following line and restart the PostgreSQL service.
```
host	imgriodb	imgriouser	127.0.0.1/0	md5

```
```
systemctl restart postgresql

```

## imgrio-api

When the PostgreSQL database is up and running, we can continue with cloning this repository and navigating to the `imgrio-api` project.
Then run the following command to build the imgrio-api image locally. After that we can savely stop the container again.
```
git clone https://github.com/baeni/imgrio.git
cd imgrio/imgrio-api
```
```
docker compose up -d --build
docker compose down
```

As we now have the image, let's push it to our Docker-Hub registry. Make sure the image's name is prefixed with the name of the registry.
```
docker login
docker push bennysaa/imgrio:api-0.1.0
```

Next up let's connect to the server where the imgrio-api should run and create a folder (e.g. `imgrio-api`) to paste the `docker-compose-prod.yml` file from this repository in.
Then start the container.
```
mkdir imgrio-api

```
```
docker compose -f docker-compose-prod.yml up -d

```

Last but not least we need to start the NGINX server within our container to be able to reach the imgrio-api from out (sub-)domain.
```
docker ps # to get the containerId
docker exec -it <containerId> /bin/bash
```
```
systemctl start nginx

```

Congratulations! - The imgrio-api is now running and accessible from https://api.imgrio.com
