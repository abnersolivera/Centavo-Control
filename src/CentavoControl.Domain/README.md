# CentavoControl.Domain

Nucleo de negocio do CentavoControl.

## Responsabilidades

- modelar entidades e invariantes de negocio
- representar linguagem ubiqua do dominio financeiro
- definir contratos de repositorio via interfaces

## Conteudo atual

- entidade base: `Entity`
- entidades: `Conta`, `Transacao`, `Transferencia`, `CartaoCredito`, `Categoria`, `Fatura`, `Usuario`
- enums para tipos de conta, transacao e cartao
- interfaces de repositorio em `Interfaces/`

## Regras arquiteturais

- nao depende de infraestrutura nem web
- regras criticas ficam nesta camada
- operacoes sensiveis (como transferencia) devem preservar consistencia
