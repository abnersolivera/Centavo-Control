namespace CentavoControl.Domain.Entities
{
    public class Conta : Entity
    {
        public string Nome { get; private set; }
        public decimal Saldo { get; private set; }
        public decimal LimiteChequeEspecial { get; private set; }
        public Guid UsuarioId { get; private set; }
        public ICollection<Transacao> Transacoes { get; private set; }
        public ICollection<Transferencia> TransferenciasOrigem { get; private set; }
        public ICollection<Transferencia> TransferenciasDestino { get; private set; }

            private Conta()
            {
                Nome = string.Empty;
                Transacoes = new List<Transacao>();
                TransferenciasOrigem = new List<Transferencia>();
                TransferenciasDestino = new List<Transferencia>();
            }

        public Conta(string nome, Guid usuarioId, decimal saldo = 0, decimal limiteChequeEspecial = 0)
        {
            Nome = nome;
            Saldo = saldo;
            LimiteChequeEspecial = limiteChequeEspecial;
            UsuarioId = usuarioId;
            Transacoes = new List<Transacao>();
            TransferenciasOrigem = new List<Transferencia>();
            TransferenciasDestino = new List<Transferencia>();
        }

        public void Creditar(decimal valor)
        {
            if (valor <= 0)
                AddNotification("Valor para crédito deve ser maior que zero.");
            
            Saldo += valor;
        }

        public bool TemSaldoDisponivel(decimal valor)
        {
            return (Saldo + LimiteChequeEspecial) >= valor;
        }

        public void Debitar(decimal valor)
        {
            if (valor <= 0)
            {
                AddNotification("Valor para débito deve ser maior que zero.");
                return;
            }

            if (!TemSaldoDisponivel(valor))
            {
                AddNotification($"Saldo insuficiente. Saldo atual: {Saldo}, limite: {LimiteChequeEspecial}.");
                return;
            }

            Saldo -= valor;
        }
    }
}
