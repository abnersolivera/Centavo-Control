using CentavoControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentavoControl.Infrastructure.Persistence.Configurations;

public class CartaoCreditoConfiguration : IEntityTypeConfiguration<CartaoCredito>
{
    public void Configure(EntityTypeBuilder<CartaoCredito> builder)
    {
        builder.ToTable("CartoesCredito");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .HasMaxLength(120)
            .IsRequired();

        builder.Property(x => x.Limite)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.LimiteUtilizado)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.DiaFechamento)
            .IsRequired();

        builder.Property(x => x.DiaVencimento)
            .IsRequired();

        builder.Property(x => x.UsuarioId)
            .IsRequired();
    }
}

