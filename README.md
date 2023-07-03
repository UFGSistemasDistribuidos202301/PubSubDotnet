# Execução

## Criar network no Docker

-   `docker network create pubsub`

## RabbitMQ

-   `docker pull rabbitmq`
-   `docker run -d --name rabbitmq-container --network pubsub --hostname rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq`

## Publisher

-   `docker pull ziinahzoor/sd-publisher`
-   `docker run --rm --name sd-publisher --network pubsub -it ziinahzoor/sd-publisher`

## Subscriber

-   `docker pull ziinahzoor/sd-subscriber`
-   `docker run --rm --name sd-subscriber --network pubsub -it ziinahzoor/sd-subscriber`
