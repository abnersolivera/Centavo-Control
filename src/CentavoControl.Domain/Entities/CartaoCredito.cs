using System;

namespace CentavoControl.Domain.Entities
{
    public class CartaoCredito : Entity
    {
        public string Nome { get; private set; }
        public decimal Limite { get; private set; }
        public DateTime DiaFechamento { get; private set; }
        public DateTime DiaVencimento { get; private set; }
        public Guid UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }

        public CartaoCredito(string nome, decimal limite, DateTime diaFechamento, DateTime diaVencimento, Usuario usuario)
        {
            Nome = nome;
            Limite = limite;
            DiaFechamento = diaFechamento;
            DiaVencimento = diaVencimento;
            Usuario = usuario;
            UsuarioId = usuario.Id;
        }
    }
}
