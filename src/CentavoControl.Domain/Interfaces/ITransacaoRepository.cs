using System;
using System.Collections.Generic;
using CentavoControl.Domain.Enums;

namespace CentavoControl.Domain.Interfaces
{
    public interface ITransacaoRepository : IRepository<Entities.Transacao>
    {
        IEnumerable<Entities.Transacao> ObterPorPeriodo(DateTime inicio, DateTime fim);
        IEnumerable<Entities.Transacao> ObterPorConta(Guid contaId);
        IEnumerable<Entities.Transacao> ObterPorCartao(Guid cartaoCreditoId);
        IEnumerable<Entities.Transacao> ObterPorTipo(TipoTransacao tipo);
        IEnumerable<Entities.Transacao> ObterPorCategoria(Guid categoriaId);
    }
}
