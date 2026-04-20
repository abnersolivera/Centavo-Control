using CentavoControl.Domain.Entities;
using CentavoControl.Infrastructure.Persistence;
using CentavoControl.Infrastructure.Repositories;
using CentavoControl.IntegrationTests.Fixtures;
using FluentAssertions;

namespace CentavoControl.IntegrationTests.Repositories;

public class UsuarioRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _fixture;
    private readonly CentavoControlDbContext _context;

    public UsuarioRepositoryIntegrationTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
        _context = fixture.DbContext;
    }

    [Fact]
    public async Task Add_DevePersistirUsuario()
    {
        var repository = new UsuarioRepository(_context);
        var usuario = new Usuario("Joao Silva", "joao@teste.com", "hash-seguro");

        repository.Add(usuario);

        var resultado = _context.Usuarios.FirstOrDefault(x => x.Email == "joao@teste.com");
        resultado.Should().NotBeNull();
        resultado!.Nome.Should().Be("Joao Silva");
    }

    [Fact]
    public async Task GetById_DeveRetornarUsuarioPersistido()
    {
        var repository = new UsuarioRepository(_context);
        var usuario = new Usuario("Maria", "maria@teste.com", "hash-seguro");
        repository.Add(usuario);

        var resultado = repository.GetById(usuario.Id);

        resultado.Should().NotBeNull();
        resultado.Email.Should().Be("maria@teste.com");
    }

    [Fact]
    public async Task GetAll_DeveRetornarTodosUsuarios()
    {
        var repository = new UsuarioRepository(_context);
        repository.Add(new Usuario("User1", "user1@teste.com", "hash1"));
        repository.Add(new Usuario("User2", "user2@teste.com", "hash2"));

        var resultado = repository.GetAll().ToList();

        resultado.Should().HaveCountGreaterThanOrEqualTo(2);
    }

    [Fact]
    public async Task ObterPorEmail_DeveRetornarUsuarioCorreto()
    {
        var repository = new UsuarioRepository(_context);
        var usuario = new Usuario("Test", "test@mail.com", "hash");
        repository.Add(usuario);

        var resultado = repository.ObterPorEmail("test@mail.com");

        resultado.Should().NotBeNull();
        resultado.Id.Should().Be(usuario.Id);
    }
}

