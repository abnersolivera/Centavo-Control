namespace CentavoControl.Domain.Entities
{
    public class Transferencia : Entity
    {
        public Guid ContaOrigemId { get; private set; }
        public Guid ContaDestinoId { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Data { get; private set; }
        public Guid UsuarioId { get; private set; }
        public Conta? ContaOrigem { get; private set; }
        public Conta? ContaDestino { get; private set; }

        public Transferencia(Guid usuarioId, Guid contaOrigemId, Guid contaDestinoId, decimal valor, DateTime data)
        {
            UsuarioId = usuarioId;
            ContaOrigemId = contaOrigemId;
            ContaDestinoId = contaDestinoId;
            Valor = valor;
            Data = data;

            ValidarTransferencia();
        }

        private void ValidarTransferencia()
        {
            if (ContaOrigemId == ContaDestinoId)
                AddNotification("Conta de origem e destino não podem ser iguais.");

            if (Valor <= 0)
                AddNotification("Valor de transferência deve ser maior que zero.");
        }

        // Validação de saldo é responsabilidade da aplicação após carregar contas
        public bool ValidarSaldoDisponivel(Conta contaOrigem)
        {
            if (contaOrigem == null)
            {
                AddNotification("Conta de origem não encontrada.");
                return false;
            }

            if (!contaOrigem.TemSaldoDisponivel(Valor))
            {
                AddNotification($"Saldo insuficiente na conta de origem para transferência de {Valor:C}.");
                return false;
            }

            return true;
        }
    }
}
