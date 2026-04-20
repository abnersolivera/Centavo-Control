using System;
using System.Collections.Generic;

namespace CentavoControl.Domain.Interfaces
{
    public interface ITransacaoRepository : IRepository<Entities.Transacao>
    {
        IEnumerable<Entities.Transacao> ObterPorPeriodo(DateTime inicio, DateTime fim);
    }
}
