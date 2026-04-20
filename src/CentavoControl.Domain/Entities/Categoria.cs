using System.Collections.Generic;

namespace CentavoControl.Domain.Entities
{
    public class Categoria : Entity
    {
        public string Nome { get; private set; }
        public string? Descricao { get; private set; }
        public ICollection<Transacao> Transacoes { get; private set; }

            private Categoria()
            {
                Nome = string.Empty;
                Transacoes = new List<Transacao>();
            }

        public Categoria(string nome, string? descricao = null)
        {
            if (string.IsNullOrWhiteSpace(nome))
                AddNotification("Nome da categoria é obrigatório.");

            Nome = nome;
            Descricao = descricao;
            Transacoes = new List<Transacao>();
        }

        public void AdicionarTransacao(Transacao? transacao)
        {
            if (transacao == null)
            {
                AddNotification("Transação inválida.");
                return;
            }

            Transacoes.Add(transacao);
        }
    }
}
