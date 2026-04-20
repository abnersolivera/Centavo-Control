using System;
using System.Collections.Generic;
using CentavoControl.Domain.Entities;

namespace CentavoControl.Domain.Interfaces
{
    public interface ICartaoCreditoRepository : IRepository<CartaoCredito>
    {
        IEnumerable<CartaoCredito> ObterPorUsuario(Guid usuarioId);
    }
}
