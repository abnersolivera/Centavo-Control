using CentavoControl.Domain.Entities;
using CentavoControl.Domain.Interfaces;
using CentavoControl.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CentavoControl.Infrastructure.Repositories;

public class ContaRepository : Repository<Conta>, IContaRepository
{
    public ContaRepository(CentavoControlDbContext context) : base(context)
    {
    }

    public IEnumerable<Conta> ObterPorUsuario(Guid usuarioId)
    {
        return Context.Contas
            .AsNoTracking()
            .Where(x => x.UsuarioId == usuarioId)
            .ToList();
    }

    public override Conta GetById(Guid id)
    {
        var entity = Context.Contas
            .Include(x => x.Transacoes)
            .Include(x => x.TransferenciasOrigem)
            .Include(x => x.TransferenciasDestino)
            .FirstOrDefault(x => x.Id == id);

        return entity ?? throw new KeyNotFoundException($"Conta com id '{id}' nao encontrada.");
    }
}

