using CentavoControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentavoControl.Infrastructure.Persistence.Configurations;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("Categorias");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .HasMaxLength(120)
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasMaxLength(300);

        builder.HasMany(x => x.Transacoes)
            .WithOne(x => x.Categoria)
            .HasForeignKey(x => x.CategoriaId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}

