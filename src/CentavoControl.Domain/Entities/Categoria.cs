namespace CentavoControl.Domain.Entities
{
    public class Categoria : Entity
    {
        public string Nome { get; private set; }
        public string? Descricao { get; private set; }
        public ICollection<Transacao> Transacoes { get; private set; }

        public Categoria(string nome, string? descricao = null)
        {
            Nome = nome;
            Descricao = descricao;
            Transacoes = new List<Transacao>();
        }
    }
}
