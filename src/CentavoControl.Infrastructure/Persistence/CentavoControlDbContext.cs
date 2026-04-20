using CentavoControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CentavoControl.Infrastructure.Persistence;

public class CentavoControlDbContext : DbContext
{
    public CentavoControlDbContext(DbContextOptions<CentavoControlDbContext> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Conta> Contas => Set<Conta>();
    public DbSet<Transacao> Transacoes => Set<Transacao>();
    public DbSet<Transferencia> Transferencias => Set<Transferencia>();
    public DbSet<CartaoCredito> CartoesCredito => Set<CartaoCredito>();
    public DbSet<Fatura> Faturas => Set<Fatura>();
    public DbSet<Categoria> Categorias => Set<Categoria>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CentavoControlDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}

