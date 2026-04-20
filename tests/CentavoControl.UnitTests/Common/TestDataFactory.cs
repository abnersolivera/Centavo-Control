using CentavoControl.Domain.Entities;

namespace CentavoControl.UnitTests.Common;

internal static class TestDataFactory
{
    public static Usuario CreateUsuario(string nome = "Joao", string email = "joao@teste.com")
    {
        return new Usuario(nome, email, "hash-seguro");
    }

    public static Conta CreateConta(Usuario usuario, decimal saldo = 100m, decimal limite = 50m, string nome = "Conta Principal")
    {
        return new Conta(nome, usuario.Id, saldo, limite);
    }

    public static CartaoCredito CreateCartao(Usuario usuario, decimal limite = 1000m)
    {
        return new CartaoCredito("Cartao Visa", limite, DateTime.Today, DateTime.Today.AddDays(10), usuario);
    }
}

