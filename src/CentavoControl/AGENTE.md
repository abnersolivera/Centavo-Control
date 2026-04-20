# 🤖 AGENTE.md – CentavoControl

## 📌 Propósito do Agente

Este agente atua como guia técnico e arquitetural do **CentavoControl**, garantindo consistência, qualidade e evolução sustentável do sistema.

Todas as decisões devem seguir:

- Domain-Driven Design (DDD)
- Clean Architecture
- Clean Code
- Práticas modernas de engenharia de software

---

## 🧠 Visão do Produto

O **CentavoControl** é uma API de controle financeiro pessoal com foco em clareza financeira, organização e previsibilidade.

O sistema permite:

- Controle de receitas (recorrentes e pontuais)
- Controle de despesas (recorrentes, pontuais e parceladas)
- Gestão de cartões de crédito
- Gestão de contas bancárias
- Transferências entre contas
- Controle de faturas

---

## 🏗️ Arquitetura do Projeto

### Estrutura de Pastas
/src
/CentavoControl.Domain
/CentavoControl.Application
/CentavoControl.Infrastructure
/CentavoControl

/tests
/CentavoControl.UnitTests
/CentavoControl.IntegrationTests

/docs
/context
/decisions
/flows


---

## 📐 Diretrizes Arquiteturais

### 🔹 Domain
- Núcleo do sistema
- Contém regras de negócio
- Independente de frameworks

**Contém:**
- Entidades
- Value Objects
- Aggregates
- Interfaces de repositório

---

### 🔹 Application
- Orquestra os casos de uso
- Não contém regra de negócio complexa

**Contém:**
- Use Cases
- DTOs
- Interfaces de serviços

---

### 🔹 Infrastructure
- Implementações técnicas

**Responsabilidades:**
- EF Core + SQL Server
- Integração com Google Auth
- Repositórios concretos

---

### 🔹 WebApi
- Entrada da aplicação

**Responsabilidades:**
- Controllers
- Middlewares
- Configuração JWT
- Swagger

---

## 💰 Regras de Negócio

### 📥 Receitas
- Tipos:
  - Recorrente
  - Pontual

---

### 📤 Despesas
- Tipos:
  - Recorrente
  - Pontual
  - Parcelada

---

### 💳 Cartões de Crédito
- Cadastro de múltiplos cartões
- Controle de:
  - Limite
  - Fechamento
  - Vencimento
- Fatura gerada automaticamente

---

### 🏦 Contas Bancárias
- Controle de saldo
- Suporte a cheque especial

---

### 🔁 Transferências
- Entre contas do mesmo usuário
- Deve manter consistência (transação atômica)

---

## 🔐 Autenticação

- JWT como padrão
- Integração com Google:
  - Login externo
  - Validação de identidade
- API responsável por gerar token interno

---

## 🧪 Testes

### ✔️ Unitários
- Foco no domínio

### ✔️ Integração
- Fluxo completo da aplicação

**Stack sugerida:**
- Testcontainers
- SQL Server em Docker
- WebApplicationFactory

---

## 🐳 Infraestrutura

- SQL Server via Docker
- Ambiente isolado para testes e desenvolvimento

---

## 🧾 Documentação Viva (/docs)

### 📁 /context

Utilizar:

## 👉 ADR (Architecture Decision Records)

Formato padrão:
ADR 000X - Título
Contexto

Problema ou necessidade

Decisão

O que foi decidido

Consequências

Impactos e trade-offs


---

### 📁 /decisions
- Decisões técnicas importantes

### 📁 /flows
- Fluxos do sistema

---

## 🧠 Memória do Projeto

O agente deve:

- Consultar `/docs` antes de propor mudanças
- Evitar retrabalho
- Respeitar decisões já tomadas
- Atualizar documentação sempre que necessário

---

## ⚙️ Padrões e Boas Práticas

- SOLID
- Clean Code
- Baixo acoplamento
- Alta coesão

**Sugestões técnicas:**
- MediatR (opcional)
- FluentValidation
- Result Pattern

---

## 📦 Principais Entidades

- User
- Account
- Transaction
- CreditCard
- Invoice
- Category

---

## ⚠️ Regras Críticas

- Regra de negócio → apenas no Domain
- Infrastructure não contém regra de negócio
- Controllers devem ser finos
- Application não acessa banco diretamente

---

## 🚀 Evolução do CentavoControl

Possíveis próximos passos:

- Dashboard financeiro
- Alertas inteligentes
- Planejamento financeiro
- Integração com Open Finance
- Motor de recomendação com IA

---

## 🎯 Objetivo

O **CentavoControl** deve ser uma API:

- Escalável
- Testável
- Organizada
- Pronta para crescimento real

---

## 📌 Comportamento Esperado do Agente

Sempre que atuar:

1. Validar contexto existente
2. Seguir arquitetura definida
3. Evitar soluções acopladas
4. Priorizar simplicidade
5. Registrar decisões relevantes (ADR)

---
