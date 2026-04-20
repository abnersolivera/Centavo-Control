using CentavoControl.Domain.Entities;
using CentavoControl.Domain.Enums;
using CentavoControl.Infrastructure.Persistence;
using CentavoControl.Infrastructure.Repositories;
using CentavoControl.IntegrationTests.Fixtures;
using FluentAssertions;

namespace CentavoControl.IntegrationTests.Repositories;

public class TransacaoRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _fixture;
    private readonly CentavoControlDbContext _context;

    public TransacaoRepositoryIntegrationTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
        _context = fixture.DbContext;
    }

    [Fact]
    public async Task Add_DevePersistirTransacao()
    {
        var usuarioRepo = new UsuarioRepository(_context);
        var usuario = new Usuario("Teste", "teste@mail.com", "hash");
        usuarioRepo.Add(usuario);

        var contaRepo = new ContaRepository(_context);
        var conta = new Conta("Conta Teste", usuario.Id, 1000m, 0m);
        contaRepo.Add(conta);

        var transacaoRepo = new TransacaoRepository(_context);
        var transacao = new Transacao(50m, DateTime.Today, "Compra", TipoTransacao.Despesa, conta.Id);
        transacaoRepo.Add(transacao);

        var resultado = _context.Transacoes.FirstOrDefault(x => x.Id == transacao.Id);
        resultado.Should().NotBeNull();
        resultado!.Valor.Should().Be(50m);
        resultado.Tipo.Should().Be(TipoTransacao.Despesa);
    }

    [Fact]
    public async Task ObterPorConta_DeveRetornarTransacoesDaConta()
    {
        var usuarioRepo = new UsuarioRepository(_context);
        var usuario = new Usuario("Joao", "joao@mail.com", "hash");
        usuarioRepo.Add(usuario);

        var contaRepo = new ContaRepository(_context);
        var conta = new Conta("Conta", usuario.Id, 5000m, 0m);
        contaRepo.Add(conta);

        var transacaoRepo = new TransacaoRepository(_context);
        transacaoRepo.Add(new Transacao(100m, DateTime.Today, "T1", TipoTransacao.Receita, conta.Id));
        transacaoRepo.Add(new Transacao(50m, DateTime.Today, "T2", TipoTransacao.Despesa, conta.Id));

        var resultado = transacaoRepo.ObterPorConta(conta.Id).ToList();

        resultado.Should().HaveCount(2);
        resultado.Should().AllSatisfy(x => x.ContaId.Should().Be(conta.Id));
    }

    [Fact]
    public async Task ObterPorTipo_DeveRetornarTransacoesFiltradas()
    {
        var usuarioRepo = new UsuarioRepository(_context);
        var usuario = new Usuario("Maria", "maria@mail.com", "hash");
        usuarioRepo.Add(usuario);

        var contaRepo = new ContaRepository(_context);
        var conta = new Conta("Conta Maria", usuario.Id, 2000m, 0m);
        contaRepo.Add(conta);

        var transacaoRepo = new TransacaoRepository(_context);
        transacaoRepo.Add(new Transacao(200m, DateTime.Today, "Salario", TipoTransacao.Receita, conta.Id));
        transacaoRepo.Add(new Transacao(50m, DateTime.Today, "Supermercado", TipoTransacao.Despesa, conta.Id));
        transacaoRepo.Add(new Transacao(100m, DateTime.Today, "Bonus", TipoTransacao.Receita, conta.Id));

        var resultado = transacaoRepo.ObterPorTipo(TipoTransacao.Receita).ToList();

        resultado.Should().HaveCountGreaterThanOrEqualTo(2);
        resultado.Should().AllSatisfy(x => x.Tipo.Should().Be(TipoTransacao.Receita));
    }
}

