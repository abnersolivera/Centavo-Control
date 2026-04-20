using CentavoControl.Domain.Entities;
using CentavoControl.Domain.Interfaces;
using CentavoControl.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CentavoControl.Infrastructure.Repositories;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(CentavoControlDbContext context) : base(context)
    {
    }

    public override Categoria GetById(Guid id)
    {
        var entity = Context.Categorias
            .AsNoTracking()
            .Include(x => x.Transacoes)
            .FirstOrDefault(x => x.Id == id);

        return entity ?? throw new KeyNotFoundException($"Categoria com id '{id}' nao encontrada.");
    }
}

