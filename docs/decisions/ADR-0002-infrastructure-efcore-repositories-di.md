# ADR-0002 - Infrastructure com EF Core, Repositorios e DI

## Status

Aceito

## Contexto

A solucao precisava de uma camada Infrastructure funcional para:

- persistir entidades do dominio com SQL Server
- implementar interfaces de repositorio do Domain
- centralizar composicao de dependencias da persistencia
- manter separacao por camadas conforme Clean Architecture

## Decisao

Foi adotado o seguinte desenho:

1. `CentavoControlDbContext` na camada Infrastructure
2. mapeamentos por entidade via Fluent API em `Persistence/Configurations`
3. repositorio generico `Repository<T>` + repositorios especificos
4. extensao `AddInfrastructure` para registrar:
   - `DbContext`
   - repositorios concretos
5. registro da Infrastructure na WebApi via `Program.cs`

## Consequencias

### Positivas

- padroniza acesso a dados
- reduz acoplamento da WebApi com detalhes de persistencia
- facilita evolucao para migrations e testes de integracao
- mantem contratos no Domain e implementacoes na Infrastructure

### Trade-offs

- repositorios atuais sao sincronos (interfaces atuais)
- ha aumento de complexidade operacional (migrations, connection string)
- regras de performance ainda dependem de revisao em consultas mais pesadas

## Referencias

- `src/CentavoControl.Infrastructure/Persistence/CentavoControlDbContext.cs`
- `src/CentavoControl.Infrastructure/Repositories/`
- `src/CentavoControl.Infrastructure/DependencyInjection/InfrastructureServiceCollectionExtensions.cs`
- `src/CentavoControl/Program.cs`

