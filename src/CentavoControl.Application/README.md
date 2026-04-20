# CentavoControl.Application

Camada que orquestra casos de uso da aplicacao.

## Responsabilidades

- implementar fluxos de negocio sem acoplamento a framework
- coordenar entidades e repositorios via contratos
- definir DTOs, comandos e consultas

## Dependencias

- depende apenas de `CentavoControl.Domain`

## Diretrizes

- nao conter regra de negocio complexa de dominio
- nao acessar banco diretamente
- manter use cases pequenos e testaveis
