# Documentacao CentavoControl

Indice central da documentacao tecnica do projeto.

## Estrutura

- `context/`: contexto arquitetural e modelagem geral
- `decisions/`: ADRs (Architecture Decision Records)
- `flows/`: fluxos funcionais e operacionais

## Infrastructure

- `context/onboarding-infrastructure.md`: visao rapida da camada
- `context/configuracao-local.md`: setup local e variaveis
- `context/migrations-efcore.md`: fluxo de migrations EF Core
- `context/mapa-repositorios.md`: interfaces x implementacoes
- `context/checklist-validacao-infrastructure.md`: checklist de validacao
- `decisions/ADR-0002-infrastructure-efcore-repositories-di.md`: decisao arquitetural da camada

## Leitura recomendada

1. `context/project-context.md`
2. `decisions/ADR-0001-arquitetura-base.md`
3. `decisions/ADR-0002-infrastructure-efcore-repositories-di.md`
4. `context/onboarding-infrastructure.md`
5. `flows/fluxos-principais.md`

## Convencoes

- linguagem padrao: portugues tecnico
- decisoes relevantes devem gerar novo ADR
- mudancas de fluxo devem atualizar `flows/`

