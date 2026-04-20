# Checklist de Validacao - Infrastructure

Use este checklist apos alteracoes na camada Infrastructure.

## 1. Build

- [ ] `CentavoControl.Infrastructure` compila sem erros
- [ ] `CentavoControl.Domain` e `CentavoControl.Application` compativeis

## 2. DbContext e mapeamentos

- [ ] `CentavoControlDbContext` contem `DbSet` para todas entidades
- [ ] classes em `Persistence/Configurations` aplicadas via `ApplyConfigurationsFromAssembly`
- [ ] FKs e `DeleteBehavior` revisados

## 3. Repositorios

- [ ] todos contratos do Domain possuem implementacao concreta
- [ ] metodos especificos estao implementados
- [ ] consultas com `AsNoTracking` onde aplicavel para leitura

## 4. DI

- [ ] `AddInfrastructure` registra `DbContext`
- [ ] `AddInfrastructure` registra todos repositorios
- [ ] `Program.cs` chama `AddInfrastructure(builder.Configuration)`

## 5. Configuracao

- [ ] `DefaultConnection` presente em `appsettings*.json`
- [ ] credenciais de producao nao hardcoded

## 6. Migrations

- [ ] migration criada para mudancas de modelo
- [ ] `database update` executado no ambiente alvo

## 7. Qualidade

- [ ] sem regra de negocio na Infrastructure
- [ ] contratos continuam no Domain
- [ ] docs atualizadas (`docs/context` e `docs/decisions`)

