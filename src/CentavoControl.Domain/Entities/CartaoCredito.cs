namespace CentavoControl.Domain.Entities
{
    public class CartaoCredito : Entity
    {
        public string Nome { get; private set; }
        public decimal Limite { get; private set; }
        public decimal LimiteUtilizado { get; private set; }
        public DateTime DiaFechamento { get; private set; }
        public DateTime DiaVencimento { get; private set; }
        public Guid UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }

            private CartaoCredito()
            {
                Nome = string.Empty;
                Usuario = null!;
            }

        public CartaoCredito(string nome, decimal limite, DateTime diaFechamento, DateTime diaVencimento, Usuario usuario)
        {
            Nome = nome;
            Limite = limite;
            LimiteUtilizado = 0;
            DiaFechamento = diaFechamento;
            DiaVencimento = diaVencimento;
            Usuario = usuario;
            UsuarioId = usuario.Id;
        }

        public decimal ObterSaldoDisponivel() => Limite - LimiteUtilizado;

        public bool TemSaldoDisponivel(decimal valor)
        {
            return ObterSaldoDisponivel() >= valor;
        }

        public void UtilizarLimite(decimal valor)
        {
            if (valor <= 0)
            {
                AddNotification("Valor deve ser maior que zero.");
                return;
            }

            if (!TemSaldoDisponivel(valor))
            {
                AddNotification($"Limite insuficiente. Disponível: {ObterSaldoDisponivel():C}.");
                return;
            }

            LimiteUtilizado += valor;
        }

        public void LiberarLimite(decimal valor)
        {
            if (valor <= 0)
                return;

            LimiteUtilizado = Math.Max(0, LimiteUtilizado - valor);
        }
    }
}
