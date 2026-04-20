# Guia de Execucao - Infrastructure Integration Tests

## Escopo

Testes de integracao para a camada Infrastructure, validando:

- conexao com banco de dados real
- mapeamentos EF Core
- persistencia e leitura de dados
- operacoes de repositorio

## Pre-requisitos

- .NET SDK compativel
- Docker instalado (para Testcontainers)
- Permissoes de criar containers Docker

## Executar testes de integracao

```powershell
dotnet test "C:\dev\Centavo-Control\tests\CentavoControl.IntegrationTests\CentavoControl.IntegrationTests.csproj" -c Debug
```

## Nota importante

- primeira execucao pode demorar varios minutos (baixa imagem SQL Server 2022)
- Testcontainers cria, executa e limpa containers automaticamente
- nao deixa artefatos no docker local apos conclusao

