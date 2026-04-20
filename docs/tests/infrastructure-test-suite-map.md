# Mapa da Suite - Infrastructure Integration Tests

## Projeto

- Test project: `tests/CentavoControl.IntegrationTests`

## Arquivos de teste

| Categoria | Arquivo de Teste |
|---|---|
| DbContext | `Persistence/DbContextIntegrationTests.cs` |
| Usuario | `Repositories/UsuarioRepositoryIntegrationTests.cs` |
| Conta | `Repositories/ContaRepositoryIntegrationTests.cs` |
| Transacao | `Repositories/TransacaoRepositoryIntegrationTests.cs` |
| CartaoCredito | `Repositories/CartaoCreditoRepositoryIntegrationTests.cs` |

## Fixture compartilhada

- `Fixtures/DatabaseFixture.cs`: inicia/para container SQL Server, aplica migrations

