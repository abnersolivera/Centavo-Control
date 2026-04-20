using CentavoControl.Domain.Entities;
using CentavoControl.Domain.Interfaces;
using CentavoControl.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CentavoControl.Infrastructure.Repositories;

public class TransferenciaRepository : Repository<Transferencia>, ITransferenciaRepository
{
    public TransferenciaRepository(CentavoControlDbContext context) : base(context)
    {
    }

    public override Transferencia GetById(Guid id)
    {
        var entity = Context.Transferencias
            .AsNoTracking()
            .Include(x => x.ContaOrigem)
            .Include(x => x.ContaDestino)
            .FirstOrDefault(x => x.Id == id);

        return entity ?? throw new KeyNotFoundException($"Transferencia com id '{id}' nao encontrada.");
    }
}

