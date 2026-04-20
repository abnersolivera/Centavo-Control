# Convencoes - Infrastructure Integration Tests

## Nomenclatura

- Classe: `<Entidade>RepositoryIntegrationTests`
- DbContext: `DbContextIntegrationTests`
- Metodo: `<Acao>_Deve<Resultado>`
  - exemplo: `Add_DevePersistirUsuario`

## Estrutura

- todos usam `IClassFixture<DatabaseFixture>`
- cada classe recebe `DatabaseFixture` no construtor
- `_context = fixture.DbContext` para access

## Ciclo de vida

- fixture inicia container antes de cada classe de teste
- fixture aplica migrations automaticamente
- fixture limpa container apos testes

## Cobertura esperada

- ao menos 1 teste de Add (persistencia)
- ao menos 1 teste de GetById (leitura)
- ao menos 1 teste de GetAll (colecao)
- ao menos 1 teste de metodo especializado do repositorio

## Boas praticas

- nao mockar o DbContext
- usar dados reais em SQL Server
- validar relacionamentos e navegacoes
- limpar fixture garante isolamento entre testes

