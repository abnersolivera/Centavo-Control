using CentavoControl.Domain.Entities;
using CentavoControl.Domain.Interfaces;
using CentavoControl.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CentavoControl.Infrastructure.Repositories;

public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(CentavoControlDbContext context) : base(context)
    {
    }

    public Usuario ObterPorEmail(string email)
    {
        var entity = Context.Usuarios
            .AsNoTracking()
            .FirstOrDefault(x => x.Email == email);

        return entity ?? throw new KeyNotFoundException($"Usuario com email '{email}' nao encontrado.");
    }

    public override Usuario GetById(Guid id)
    {
        var entity = Context.Usuarios
            .AsNoTracking()
            .Include(x => x.Contas)
            .Include(x => x.Cartoes)
            .FirstOrDefault(x => x.Id == id);

        return entity ?? throw new KeyNotFoundException($"Usuario com id '{id}' nao encontrado.");
    }
}

