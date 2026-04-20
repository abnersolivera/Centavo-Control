# Mapa de Repositorios

Mapeamento entre contratos do Domain e implementacoes da Infrastructure.

## Repositorio base

- Contrato: `IRepository<T>`
- Implementacao: `Repository<T>`

## Repositorios especificos

- `IUsuarioRepository` -> `UsuarioRepository`
- `IContaRepository` -> `ContaRepository`
- `ITransacaoRepository` -> `TransacaoRepository`
- `ITransferenciaRepository` -> `TransferenciaRepository`
- `ICartaoCreditoRepository` -> `CartaoCreditoRepository`
- `IFaturaRepository` -> `FaturaRepository`
- `ICategoriaRepository` -> `CategoriaRepository`

## Registro em DI

Todos sao registrados em:

- `src/CentavoControl.Infrastructure/DependencyInjection/InfrastructureServiceCollectionExtensions.cs`

Padrao de registro:

```csharp
services.AddScoped<IContaRepository, ContaRepository>();
```

## Observacao de evolucao

As interfaces atuais sao sincronas. Em evolucao futura, considerar versao async para workloads maiores.

