# Convencoes - Domain Unit Tests

## Nomenclatura

- Classe: `<Entidade>Tests` (ex.: `UsuarioTests`)
- Metodo: `<Acao>_<Cenario>_Deve<Resultado>`
  - exemplo: `AdicionarConta_ComOutroUsuario_DeveAdicionarNotificacao`

## Estrutura padrao

Cada teste deve seguir o padrao Arrange / Act / Assert:

1. Arrange: cria entidades e estado inicial
2. Act: executa a acao a ser testada
3. Assert: valida estado final e notificacoes

## Regras de cobertura minima por entidade

- ao menos 1 teste de caminho feliz
- ao menos 1 teste de validacao/erro
- validar efeitos colaterais de colecoes e saldos
- validar `IsValid` e `Notifications` quando houver regra de negocio

## Boas praticas

- usar `TestDataFactory` para reduzir duplicacao
- preferir asserts com `FluentAssertions`
- manter testes deterministas (sem dependencias externas)
- nao acessar banco em testes unitarios de Domain

