namespace CentavoControl.Domain.Entities
{
    public class Conta : Entity
    {
        public string Nome { get; private set; }
        public decimal Saldo { get; private set; }
        public ICollection<Transacao> Transacoes { get; private set; }
        public ICollection<Transferencia> TransferenciasOrigem { get; private set; }
        public ICollection<Transferencia> TransferenciasDestino { get; private set; }

        public Conta(string nome, decimal saldo = 0)
        {
            Nome = nome;
            Saldo = saldo;
            Transacoes = new List<Transacao>();
            TransferenciasOrigem = new List<Transferencia>();
            TransferenciasDestino = new List<Transferencia>();
        }

        public void Creditar(decimal valor) => Saldo += valor;
        public void Debitar(decimal valor) => Saldo -= valor;
    }
}
