# Fluxos principais

Este documento descreve fluxos de alto nivel para orientar implementacao e testes.

## 1) Lancar receita

1. API recebe comando de receita (recorrente ou pontual).
2. Application valida entrada e contexto.
3. Domain cria `Transacao` do tipo receita.
4. Conta destino e creditada.
5. Infrastructure persiste mudancas em transacao unica.

## 2) Lancar despesa

1. API recebe comando de despesa (pontual, recorrente ou parcelada).
2. Application define estrategia de lancamento.
3. Domain cria uma ou varias `Transacao` de despesa.
4. Conta/cartao e debitado conforme regra.
5. Infrastructure persiste e publica resultado.

## 3) Transferir entre contas

1. API recebe conta origem, destino e valor.
2. Application carrega contas e valida pre-condicoes.
3. Domain debita origem e credita destino.
4. Domain registra `Transferencia`.
5. Infrastructure confirma em operacao atomica.

## 4) Fechamento de fatura de cartao

1. Processo identifica cartoes no periodo de fechamento.
2. Transacoes elegiveis sao agregadas por cartao.
3. Domain gera/atualiza `Fatura`.
4. API/servico disponibiliza valor e vencimento.

## 5) Autenticacao externa + token interno

1. Cliente autentica via Google.
2. API valida identidade externa.
3. Application localiza ou provisiona usuario interno.
4. API emite JWT interno para autorizacao.

