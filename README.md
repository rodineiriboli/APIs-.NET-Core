# APIs-.NET-Core

Esta solução possui duas API, sendo uma com um endpoint e outra com dois enponits.
A primeira retornando uma valor fixo.
A segunda um endpoint com um calculo baseada em parametros juntamente com o valor consultado na primeira API.
E outro enpoint retornando o endereço no GitHub onde se encontra o código fonte.

OBS: Apenas para fim de avalição.

# Features!

  - .Net core api

# Requirements

 - docker
 - docker compose
 
# Running
Para rodar este projeto você precisa seguir os seguintes passos:
  - clone o projeto
  - abra sua linha de comando ou powershell
  - rode o comando na pasta do projeto: 
```sh
$ docker-compose up
```
Aguarde o build, em seguida deverá ser possivel visualizar as apis: http://localhost/swagger-Api-1
e http://localhost/swagger-Api-2
