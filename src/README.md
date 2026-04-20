# CentavoControl

API para controle financeiro pessoal, organizada com principios de DDD e Clean Architecture.

## Objetivo

O projeto busca oferecer uma base escalavel para:

- controle de receitas e despesas
- gestao de contas bancarias
- gestao de cartoes de credito e faturas
- transferencias entre contas com consistencia
- autenticacao com JWT e login externo

## Arquitetura

A solucao segue separacao por camadas:

- `CentavoControl.Domain`: entidades e regras de negocio
- `CentavoControl.Application`: casos de uso e orquestracao
- `CentavoControl.Infrastructure`: persistencia e integracoes externas
- `CentavoControl`: Web API (entrada HTTP)

Mais detalhes em `../docs/`.

## Estrutura da Solucao

```text
src/
  CentavoControl.sln
  CentavoControl/
  CentavoControl.Domain/
  CentavoControl.Application/
  CentavoControl.Infrastructure/
  ../docs/
```

## Requisitos

- .NET SDK 10
- Docker (opcional, para infraestrutura local)

## Como executar localmente

```powershell
dotnet restore "C:\dev\Centavo-Control\src\CentavoControl.sln"
dotnet build "C:\dev\Centavo-Control\src\CentavoControl.sln"
dotnet run --project "C:\dev\Centavo-Control\src\CentavoControl\CentavoControl.csproj"
```

## Como rodar testes

```powershell
dotnet test "C:\dev\Centavo-Control\src\CentavoControl.sln"
```

## Documentacao complementar

- `../docs/README.md`: indice geral
- `../docs/context/project-context.md`: contexto arquitetural
- `../docs/decisions/ADR-0001-arquitetura-base.md`: decisao de arquitetura
- `../docs/flows/fluxos-principais.md`: fluxos funcionais principais
