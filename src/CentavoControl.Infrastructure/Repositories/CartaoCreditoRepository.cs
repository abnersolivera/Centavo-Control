using CentavoControl.Domain.Entities;
using CentavoControl.Domain.Interfaces;
using CentavoControl.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CentavoControl.Infrastructure.Repositories;

public class CartaoCreditoRepository : Repository<CartaoCredito>, ICartaoCreditoRepository
{
    public CartaoCreditoRepository(CentavoControlDbContext context) : base(context)
    {
    }

    public IEnumerable<CartaoCredito> ObterPorUsuario(Guid usuarioId)
    {
        return Context.CartoesCredito
            .AsNoTracking()
            .Where(x => x.UsuarioId == usuarioId)
            .ToList();
    }

    public override CartaoCredito GetById(Guid id)
    {
        var entity = Context.CartoesCredito
            .AsNoTracking()
            .Include(x => x.Usuario)
            .FirstOrDefault(x => x.Id == id);

        return entity ?? throw new KeyNotFoundException($"CartaoCredito com id '{id}' nao encontrado.");
    }
}

