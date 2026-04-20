using CentavoControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentavoControl.Infrastructure.Persistence.Configurations;

public class ContaConfiguration : IEntityTypeConfiguration<Conta>
{
    public void Configure(EntityTypeBuilder<Conta> builder)
    {
        builder.ToTable("Contas");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .HasMaxLength(120)
            .IsRequired();

        builder.Property(x => x.Saldo)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.LimiteChequeEspecial)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.UsuarioId)
            .IsRequired();

        builder.HasMany(x => x.Transacoes)
            .WithOne(x => x.Conta)
            .HasForeignKey(x => x.ContaId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.TransferenciasOrigem)
            .WithOne(x => x.ContaOrigem)
            .HasForeignKey(x => x.ContaOrigemId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.TransferenciasDestino)
            .WithOne(x => x.ContaDestino)
            .HasForeignKey(x => x.ContaDestinoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

