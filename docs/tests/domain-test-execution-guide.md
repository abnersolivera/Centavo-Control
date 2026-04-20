# Guia de Execucao - Domain Unit Tests

## Escopo

Este guia cobre a execucao dos testes unitarios da camada Domain no projeto:

- `tests/CentavoControl.UnitTests`

## Pre-requisitos

- .NET SDK compativel com a solucao
- restore de pacotes concluido

## Executar todos os testes da suite Domain

```powershell
dotnet test "C:\dev\Centavo-Control\tests\CentavoControl.UnitTests\CentavoControl.UnitTests.csproj" -c Debug
```

## Executar apenas uma classe de teste

```powershell
dotnet test "C:\dev\Centavo-Control\tests\CentavoControl.UnitTests\CentavoControl.UnitTests.csproj" -c Debug --filter "FullyQualifiedName~UsuarioTests"
```

## Executar com cobertura (collector)

```powershell
dotnet test "C:\dev\Centavo-Control\tests\CentavoControl.UnitTests\CentavoControl.UnitTests.csproj" -c Debug --collect:"XPlat Code Coverage"
```

## Resultado esperado

- build do projeto de testes concluido
- todas as classes de entidade com cenarios de sucesso e validacao
- sem falhas na pipeline local

