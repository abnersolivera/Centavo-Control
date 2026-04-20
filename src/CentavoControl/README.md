# CentavoControl.WebApi

Camada de entrada HTTP do sistema.

## Responsabilidades

- expor endpoints REST
- configurar pipeline ASP.NET Core
- centralizar autenticacao/autorizacao
- publicar documentacao OpenAPI

## Estado atual

- projeto ASP.NET Core configurado com controllers
- OpenAPI habilitado em ambiente de desenvolvimento
- referencias para camadas `CentavoControl.Application` e `CentavoControl.Infrastructure`

## Diretrizes

- controllers finos, sem regra de negocio
- validacoes de regras no dominio e/ou aplicacao
- sem acesso direto a persistencia a partir de controllers

## Proximos passos recomendados

- adicionar endpoints de contas, transacoes e transferencias
- integrar autenticacao JWT
- configurar Swagger com seguranca
