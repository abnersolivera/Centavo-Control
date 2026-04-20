using CentavoControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentavoControl.Infrastructure.Persistence.Configurations;

public class FaturaConfiguration : IEntityTypeConfiguration<Fatura>
{
    public void Configure(EntityTypeBuilder<Fatura> builder)
    {
        builder.ToTable("Faturas");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CartaoCreditoId)
            .IsRequired();

        builder.Property(x => x.DataFechamento)
            .IsRequired();

        builder.Property(x => x.DataVencimento)
            .IsRequired();

        builder.Property(x => x.ValorTotal)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.Paga)
            .IsRequired();

        builder.HasOne(x => x.CartaoCredito)
            .WithMany()
            .HasForeignKey(x => x.CartaoCreditoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Transacoes)
            .WithMany()
            .UsingEntity(j => j.ToTable("FaturaTransacoes"));

        builder.HasIndex(x => new { x.CartaoCreditoId, x.DataFechamento });
    }
}

