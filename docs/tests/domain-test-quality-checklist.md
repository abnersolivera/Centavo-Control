# Checklist de Qualidade - Domain Unit Tests

Use este checklist antes de abrir PR.

## Build e execucao

- [ ] `dotnet test` executa sem erros
- [ ] nao ha testes intermitentes

## Cobertura de negocio

- [ ] cada entidade principal possui testes
- [ ] cenarios validos e invalidos cobertos
- [ ] validacoes via `Notifications` verificadas
- [ ] mudancas em regras de dominio atualizam testes existentes

## Legibilidade

- [ ] nomes dos testes descrevem comportamento
- [ ] Arrange/Act/Assert evidente
- [ ] sem duplicacao excessiva de setup

## Arquitetura

- [ ] testes unitarios nao dependem de Infrastructure
- [ ] testes unitarios nao usam recursos externos (DB, API, fila)
- [ ] testes focam apenas regras da camada Domain

## Documentacao

- [ ] mapa da suite atualizado em `docs/tests/domain-test-suite-map.md`
- [ ] guia de execucao refletindo comandos atuais

