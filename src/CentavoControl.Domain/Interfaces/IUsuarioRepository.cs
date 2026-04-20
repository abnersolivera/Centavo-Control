using CentavoControl.Domain.Entities;

namespace CentavoControl.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario ObterPorEmail(string email);
    }
}
