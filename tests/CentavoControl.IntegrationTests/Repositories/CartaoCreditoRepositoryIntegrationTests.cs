using CentavoControl.Domain.Entities;
using CentavoControl.Infrastructure.Persistence;
using CentavoControl.Infrastructure.Repositories;
using CentavoControl.IntegrationTests.Fixtures;
using FluentAssertions;

namespace CentavoControl.IntegrationTests.Repositories;

public class CartaoCreditoRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _fixture;
    private readonly CentavoControlDbContext _context;

    public CartaoCreditoRepositoryIntegrationTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
        _context = fixture.DbContext;
    }

    [Fact]
    public async Task Add_DevePersistirCartao()
    {
        var usuarioRepo = new UsuarioRepository(_context);
        var usuario = new Usuario("Pedro", "pedro@mail.com", "hash");
        usuarioRepo.Add(usuario);

        var cartaoRepo = new CartaoCreditoRepository(_context);
        var cartao = new CartaoCredito("Visa", 5000m, DateTime.Today, DateTime.Today.AddDays(30), usuario);
        cartaoRepo.Add(cartao);

        var resultado = _context.CartoesCredito.FirstOrDefault(x => x.Id == cartao.Id);
        resultado.Should().NotBeNull();
        resultado!.Limite.Should().Be(5000m);
        resultado.UsuarioId.Should().Be(usuario.Id);
    }

    [Fact]
    public async Task ObterPorUsuario_DeveRetornarCartoesDoUsuario()
    {
        var usuarioRepo = new UsuarioRepository(_context);
        var usuario = new Usuario("Sandra", "sandra@mail.com", "hash");
        usuarioRepo.Add(usuario);

        var cartaoRepo = new CartaoCreditoRepository(_context);
        cartaoRepo.Add(new CartaoCredito("Visa", 3000m, DateTime.Today, DateTime.Today.AddDays(30), usuario));
        cartaoRepo.Add(new CartaoCredito("Mastercard", 5000m, DateTime.Today, DateTime.Today.AddDays(30), usuario));

        var resultado = cartaoRepo.ObterPorUsuario(usuario.Id).ToList();

        resultado.Should().HaveCount(2);
        resultado.Should().AllSatisfy(x => x.UsuarioId.Should().Be(usuario.Id));
    }
}

