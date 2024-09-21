# Overview

imgrio consists of multiple components

- postgreSQL database   - provided by and hosted at https://supabase.com
- ClamAV                - living in a container on our backend-server
- imgrio-api            - living in our container on our backend-server
- imgrio-nuxt           - hosted at https://vercel.app

where the former three represent the backend, and "imgrio-nuxt" the frontend.

For storing information about the UserFiles and additional information for imgrio, the PostgreSQL database comes in place. PostgreSQL was chosen to be able to work with the EntityFramework within the imgrio-api.<br>
The keep our database and filesystem mostly clean from malicious or harmful files which some (evil) users might attempt to upload, we scan those files with clamAV before further processing them.<br>
The final part of the backend is made by the imgrio-api which handles all incoming HTTP-Requests to make things working.<br>
To give all this a personality and a pleasant face, imgrio-nuxt is also part of the whole struct.

# How to setup?

Before really getting started, we need to clone this repository.

```
git clone https://github.com/baeni/imgrio.git

```

## PostgreSQL database

First we need to create a place where UserFiles and additional information can be stored, so the imgrio-api can work properly.

To keep things simple, we are using a PostgreSQL database hosted by a thirdparty. The only configuration necessary is pasting the connection information into the appsettings.json file of the imgrio-api.

## imgrio-api

When the PostgreSQL database is up and running, we can continue with navigating to the `imgrio-api` project and run the following command to build the imgrio-api image locally.

```
cd imgrio/imgrio-api
docker compose build
```

As we now have the image, let's push it to our Docker-Hub registry. Make sure the image's name is in fact prefixed with the name of the registry.

```
docker login
docker push bennysaa/imgrio:api-0.1.0
```

Next up let's connect to the server where the imgrio backend should run and create a folder (e.g. `imgrio`) to paste the `docker-compose.yml` file from the root of this repository in.
Then execute the compose file to automatically create and start the imgrio-api and clam-av containers.

```
mkdir imgrio

```

```
docker compose up -d

```

Profit! - The imgrio-api is now running and accessible from whatever address you've configured it to. For us it's https://api.imgrio.com

## imgrio-nuxt

For Nuxt, the only thing to keep in mind is that the environment running the application has to have an environment variable called "SITE_URL" including the url to redirect to after a successfull authentication. This is only necessary when the url should NOT be "https://imgrio.com". This is useful to allow authentication to work properly in dev or beta environments.
