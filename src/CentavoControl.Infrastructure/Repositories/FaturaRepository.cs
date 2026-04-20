using CentavoControl.Domain.Entities;
using CentavoControl.Domain.Interfaces;
using CentavoControl.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CentavoControl.Infrastructure.Repositories;

public class FaturaRepository : Repository<Fatura>, IFaturaRepository
{
    public FaturaRepository(CentavoControlDbContext context) : base(context)
    {
    }

    public IEnumerable<Fatura> ObterPorCartao(Guid cartaoCreditoId)
    {
        return Context.Faturas
            .AsNoTracking()
            .Where(x => x.CartaoCreditoId == cartaoCreditoId)
            .OrderByDescending(x => x.DataFechamento)
            .ToList();
    }

    public IEnumerable<Fatura> ObterEmAberto(Guid cartaoCreditoId)
    {
        return Context.Faturas
            .AsNoTracking()
            .Where(x => x.CartaoCreditoId == cartaoCreditoId && !x.Paga)
            .OrderBy(x => x.DataVencimento)
            .ToList();
    }

    public Fatura ObterUltimaFatura(Guid cartaoCreditoId)
    {
        var entity = Context.Faturas
            .AsNoTracking()
            .Where(x => x.CartaoCreditoId == cartaoCreditoId)
            .OrderByDescending(x => x.DataFechamento)
            .FirstOrDefault();

        return entity ?? throw new KeyNotFoundException($"Nenhuma fatura encontrada para o cartao '{cartaoCreditoId}'.");
    }

    public override Fatura GetById(Guid id)
    {
        var entity = Context.Faturas
            .AsNoTracking()
            .Include(x => x.CartaoCredito)
            .Include(x => x.Transacoes)
            .FirstOrDefault(x => x.Id == id);

        return entity ?? throw new KeyNotFoundException($"Fatura com id '{id}' nao encontrada.");
    }
}

