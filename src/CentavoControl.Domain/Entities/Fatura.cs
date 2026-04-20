using System.Collections.Generic;

namespace CentavoControl.Domain.Entities
{
    public class Fatura : Entity
    {
        public Guid CartaoCreditoId { get; private set; }
        public CartaoCredito CartaoCredito { get; private set; }
        public DateTime DataFechamento { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public decimal ValorTotal { get; private set; }
        public bool Paga { get; private set; }
        public ICollection<Transacao> Transacoes { get; private set; }

        public Fatura(CartaoCredito cartaoCredito, DateTime dataFechamento, DateTime dataVencimento, decimal valorTotal)
        {
            CartaoCredito = cartaoCredito;
            CartaoCreditoId = cartaoCredito.Id;
            DataFechamento = dataFechamento;
            DataVencimento = dataVencimento;
            ValorTotal = valorTotal;
            Paga = false;
            Transacoes = new List<Transacao>();
        }

        public void AdicionarTransacao(Transacao transacao)
        {
            if (transacao == null)
            {
                AddNotification("Transação inválida.");
                return;
            }

            Transacoes.Add(transacao);
            RecalcularTotal();
        }

        public void RecalcularTotal()
        {
            ValorTotal = 0;
            foreach (var transacao in Transacoes)
            {
                ValorTotal += transacao.Valor;
            }
        }

        public void Pagar() => Paga = true;
    }
}
