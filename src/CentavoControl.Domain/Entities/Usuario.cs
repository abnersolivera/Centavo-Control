using System.Collections.Generic;

namespace CentavoControl.Domain.Entities
{
    public class Usuario : Entity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string SenhaHash { get; private set; }
        public ICollection<Conta> Contas { get; private set; }
        public ICollection<CartaoCredito> Cartoes { get; private set; }

            private Usuario()
            {
                Nome = string.Empty;
                Email = string.Empty;
                SenhaHash = string.Empty;
                Contas = new List<Conta>();
                Cartoes = new List<CartaoCredito>();
            }

        public Usuario(string nome, string email, string senhaHash)
        {
            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
            Contas = new List<Conta>();
            Cartoes = new List<CartaoCredito>();
        }

        public void AdicionarConta(Conta conta)
        {
            if (conta == null)
            {
                AddNotification("Conta inválida.");
                return;
            }

            if (conta.UsuarioId != Id)
            {
                AddNotification("Conta não pertence a este usuário.");
                return;
            }

            Contas.Add(conta);
        }

        public void AdicionarCartao(CartaoCredito cartao)
        {
            if (cartao == null)
            {
                AddNotification("Cartão inválido.");
                return;
            }

            if (cartao.UsuarioId != Id)
            {
                AddNotification("Cartão não pertence a este usuário.");
                return;
            }

            Cartoes.Add(cartao);
        }
    }
}
