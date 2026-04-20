using CentavoControl.Domain.Entities;
using CentavoControl.Domain.Enums;
using CentavoControl.Domain.Interfaces;
using CentavoControl.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CentavoControl.Infrastructure.Repositories;

public class TransacaoRepository : Repository<Transacao>, ITransacaoRepository
{
    public TransacaoRepository(CentavoControlDbContext context) : base(context)
    {
    }

    public IEnumerable<Transacao> ObterPorPeriodo(DateTime inicio, DateTime fim)
    {
        return Context.Transacoes
            .AsNoTracking()
            .Where(x => x.Data >= inicio && x.Data <= fim)
            .ToList();
    }

    public IEnumerable<Transacao> ObterPorConta(Guid contaId)
    {
        return Context.Transacoes
            .AsNoTracking()
            .Where(x => x.ContaId == contaId)
            .ToList();
    }

    public IEnumerable<Transacao> ObterPorCartao(Guid cartaoCreditoId)
    {
        return Context.Transacoes
            .AsNoTracking()
            .Where(x => x.CartaoCreditoId == cartaoCreditoId)
            .ToList();
    }

    public IEnumerable<Transacao> ObterPorTipo(TipoTransacao tipo)
    {
        return Context.Transacoes
            .AsNoTracking()
            .Where(x => x.Tipo == tipo)
            .ToList();
    }

    public IEnumerable<Transacao> ObterPorCategoria(Guid categoriaId)
    {
        return Context.Transacoes
            .AsNoTracking()
            .Where(x => x.CategoriaId == categoriaId)
            .ToList();
    }

    public override Transacao GetById(Guid id)
    {
        var entity = Context.Transacoes
            .AsNoTracking()
            .Include(x => x.Conta)
            .Include(x => x.Categoria)
            .Include(x => x.CartaoCredito)
            .FirstOrDefault(x => x.Id == id);

        return entity ?? throw new KeyNotFoundException($"Transacao com id '{id}' nao encontrada.");
    }
}

