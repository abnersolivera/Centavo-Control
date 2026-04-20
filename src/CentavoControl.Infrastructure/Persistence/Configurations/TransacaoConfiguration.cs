using CentavoControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentavoControl.Infrastructure.Persistence.Configurations;

public class TransacaoConfiguration : IEntityTypeConfiguration<Transacao>
{
    public void Configure(EntityTypeBuilder<Transacao> builder)
    {
        builder.ToTable("Transacoes");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Valor)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.Data)
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(x => x.Tipo)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.Recorrencia)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.ContaId)
            .IsRequired();

        builder.Property(x => x.DataProximaOcorrencia);
        builder.Property(x => x.Parcelas);
        builder.Property(x => x.ParcelaAtual);

        builder.HasOne(x => x.CartaoCredito)
            .WithMany()
            .HasForeignKey(x => x.CartaoCreditoId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(x => x.Data);
        builder.HasIndex(x => x.Tipo);
        builder.HasIndex(x => x.ContaId);
    }
}

