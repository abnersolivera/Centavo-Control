using CentavoControl.Domain.Entities;
using CentavoControl.Infrastructure.Persistence;
using CentavoControl.IntegrationTests.Fixtures;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace CentavoControl.IntegrationTests.Persistence;

public class DbContextIntegrationTests : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _fixture;
    private readonly CentavoControlDbContext _context;

    public DbContextIntegrationTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
        _context = fixture.DbContext;
    }

    [Fact]
    public async Task DbContext_DeveConectarComBanco()
    {
        var canConnect = await _context.Database.CanConnectAsync();
        canConnect.Should().BeTrue();
    }

    [Fact]
    public async Task DbSets_DeveConterTodasAsEntidades()
    {
        _context.Usuarios.Should().NotBeNull();
        _context.Contas.Should().NotBeNull();
        _context.Transacoes.Should().NotBeNull();
        _context.Transferencias.Should().NotBeNull();
        _context.CartoesCredito.Should().NotBeNull();
        _context.Faturas.Should().NotBeNull();
        _context.Categorias.Should().NotBeNull();
    }

    [Fact]
    public async Task Migrations_DeveExecutarCorretamente()
    {
        var pendingMigrations = await _context.Database.GetPendingMigrationsAsync();
        pendingMigrations.Should().BeEmpty();
    }
}

