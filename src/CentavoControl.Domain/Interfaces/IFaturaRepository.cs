using System;
using System.Collections.Generic;
using CentavoControl.Domain.Entities;

namespace CentavoControl.Domain.Interfaces
{
    public interface IFaturaRepository : IRepository<Fatura>
    {
        IEnumerable<Fatura> ObterPorCartao(Guid cartaoCreditoId);
        IEnumerable<Fatura> ObterEmAberto(Guid cartaoCreditoId);
        Fatura ObterUltimaFatura(Guid cartaoCreditoId);
    }
}
