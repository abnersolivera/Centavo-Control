# Onboarding Infrastructure

Este guia resume como a camada Infrastructure foi organizada.

## Objetivo da camada

A Infrastructure implementa detalhes tecnicos sem carregar regra de negocio:

- persistencia EF Core + SQL Server
- implementacao de repositorios concretos
- registro de DI para WebApi

## Estrutura principal

- `src/CentavoControl.Infrastructure/Persistence/CentavoControlDbContext.cs`
- `src/CentavoControl.Infrastructure/Persistence/Configurations/`
- `src/CentavoControl.Infrastructure/Repositories/`
- `src/CentavoControl.Infrastructure/DependencyInjection/InfrastructureServiceCollectionExtensions.cs`

## Fluxo de uso

1. WebApi inicializa DI em `Program.cs`
2. `AddInfrastructure` registra `DbContext` e repositorios
3. Application/Controllers consomem interfaces do Domain
4. Infrastructure resolve interfaces com implementacoes concretas

## Principio de fronteira

- Domain define contratos (`Interfaces/`)
- Infrastructure implementa contratos
- WebApi nao conhece detalhes de SQL/EF

