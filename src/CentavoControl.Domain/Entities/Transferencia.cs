using System;

namespace CentavoControl.Domain.Entities
{
    public class Transferencia : Entity
    {
        public Guid ContaOrigemId { get; private set; }
        public Guid ContaDestinoId { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Data { get; private set; }

        public Transferencia(Guid contaOrigemId, Guid contaDestinoId, decimal valor, DateTime data)
        {
            ContaOrigemId = contaOrigemId;
            ContaDestinoId = contaDestinoId;
            Valor = valor;
            Data = data;
        }
    }
}
