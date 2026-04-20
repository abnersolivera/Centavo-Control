using System;

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

        public Fatura(CartaoCredito cartaoCredito, DateTime dataFechamento, DateTime dataVencimento, decimal valorTotal)
        {
            CartaoCredito = cartaoCredito;
            CartaoCreditoId = cartaoCredito.Id;
            DataFechamento = dataFechamento;
            DataVencimento = dataVencimento;
            ValorTotal = valorTotal;
            Paga = false;
        }

        public void Pagar() => Paga = true;
    }
}
