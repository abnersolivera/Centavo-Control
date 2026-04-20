using CentavoControl.Domain.Entities;
using CentavoControl.Infrastructure.Persistence;
using CentavoControl.Infrastructure.Repositories;
using CentavoControl.IntegrationTests.Fixtures;
using FluentAssertions;

namespace CentavoControl.IntegrationTests.Repositories;

public class ContaRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _fixture;
    private readonly CentavoControlDbContext _context;

    public ContaRepositoryIntegrationTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
        _context = fixture.DbContext;
    }

    [Fact]
    public async Task Add_DevePersistirContaComRelacionamento()
    {
        var usuarioRepo = new UsuarioRepository(_context);
        var usuario = new Usuario("Paulo", "paulo@teste.com", "hash");
        usuarioRepo.Add(usuario);

        var contaRepo = new ContaRepository(_context);
        var conta = new Conta("Conta Corrente", usuario.Id, 1000m, 500m);
        contaRepo.Add(conta);

        var resultado = _context.Contas.FirstOrDefault(x => x.Id == conta.Id);
        resultado.Should().NotBeNull();
        resultado!.Saldo.Should().Be(1000m);
        resultado.LimiteChequeEspecial.Should().Be(500m);
    }

    [Fact]
    public async Task ObterPorUsuario_DeveRetornarContasDoUsuario()
    {
        var usuarioRepo = new UsuarioRepository(_context);
        var usuario = new Usuario("Ana", "ana@teste.com", "hash");
        usuarioRepo.Add(usuario);

        var contaRepo = new ContaRepository(_context);
        contaRepo.Add(new Conta("Conta 1", usuario.Id, 100m, 0m));
        contaRepo.Add(new Conta("Conta 2", usuario.Id, 200m, 0m));

        var resultado = contaRepo.ObterPorUsuario(usuario.Id).ToList();

        resultado.Should().HaveCount(2);
        resultado.Should().AllSatisfy(x => x.UsuarioId.Should().Be(usuario.Id));
    }

    [Fact]
    public async Task GetById_DevcarregarRelacionamentos()
    {
        var usuarioRepo = new UsuarioRepository(_context);
        var usuario = new Usuario("Carlos", "carlos@teste.com", "hash");
        usuarioRepo.Add(usuario);

        var contaRepo = new ContaRepository(_context);
        var conta = new Conta("Poupanca", usuario.Id, 5000m, 0m);
        contaRepo.Add(conta);

        var resultado = contaRepo.GetById(conta.Id);

        resultado.Should().NotBeNull();
        resultado.TransferenciasOrigem.Should().BeEmpty();
        resultado.TransferenciasDestino.Should().BeEmpty();
    }
}

