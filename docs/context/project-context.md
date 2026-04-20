# Contexto do Projeto

## Visao geral

CentavoControl e uma API para controle financeiro pessoal com separacao clara entre dominio, aplicacao, infraestrutura e API.

## Fronteiras por camada

- `CentavoControl.Domain`
  - entidades e regras de negocio
  - contratos de repositorio
- `CentavoControl.Application`
  - casos de uso, DTOs, orquestracao
- `CentavoControl.Infrastructure`
  - persistencia e integracoes externas
- `CentavoControl`
  - endpoints HTTP e configuracao da API

## Dependencias esperadas

```text
WebApi -> Application -> Domain
WebApi -> Infrastructure -> (Application, Domain)
Application -> Domain
Domain -> (sem dependencias de outras camadas)
```

## Entidades principais (estado atual)

- `Usuario`
- `Conta`
- `Transacao`
- `Transferencia`
- `CartaoCredito`
- `Fatura`
- `Categoria`

## Principios de implementacao

- regra de negocio no dominio
- controllers finos
- infraestrutura sem regras de negocio
- use cases pequenos e testaveis

