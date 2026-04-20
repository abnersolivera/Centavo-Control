using System;
using System.Collections.Generic;
using CentavoControl.Domain.Entities;

namespace CentavoControl.Domain.Interfaces
{
    public interface IContaRepository : IRepository<Conta>
    {
        IEnumerable<Conta> ObterPorUsuario(Guid usuarioId);
    }
}
