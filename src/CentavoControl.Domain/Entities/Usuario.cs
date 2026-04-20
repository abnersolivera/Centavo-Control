namespace CentavoControl.Domain.Entities
{
    public class Usuario : Entity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string SenhaHash { get; private set; }

        public Usuario(string nome, string email, string senhaHash)
        {
            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
        }
    }
}
