using CentavoControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentavoControl.Infrastructure.Persistence.Configurations;

public class TransferenciaConfiguration : IEntityTypeConfiguration<Transferencia>
{
    public void Configure(EntityTypeBuilder<Transferencia> builder)
    {
        builder.ToTable("Transferencias");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Valor)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.Data)
            .IsRequired();

        builder.Property(x => x.UsuarioId)
            .IsRequired();

        builder.Property(x => x.ContaOrigemId)
            .IsRequired();

        builder.Property(x => x.ContaDestinoId)
            .IsRequired();

        builder.HasIndex(x => x.Data);
        builder.HasIndex(x => x.UsuarioId);
    }
}

