# ADR-0001 - Arquitetura base em DDD + Clean Architecture

## Status

Aceito

## Contexto

O projeto CentavoControl precisa evoluir com baixo acoplamento, alta testabilidade e clareza de responsabilidades para suportar novos modulos financeiros.

## Decisao

Adotar separacao por camadas:

- `Domain`: regras de negocio e entidades
- `Application`: casos de uso e orquestracao
- `Infrastructure`: detalhes tecnicos e adaptadores
- `WebApi`: interface HTTP

Regras complementares:

- dominio nao depende de infraestrutura
- controllers nao contem regra de negocio
- application nao acessa banco diretamente

## Consequencias

### Positivas

- facilita testes unitarios no dominio
- reduz impacto de mudancas tecnicas
- melhora legibilidade do fluxo de negocio

### Trade-offs

- maior numero de projetos e contratos
- necessidade de disciplina para manter fronteiras

## Revisao futura

Revisar esta ADR quando houver:

- introducao de mensageria/eventos de dominio
- adocao de CQRS completo
- mudanca significativa de infraestrutura

