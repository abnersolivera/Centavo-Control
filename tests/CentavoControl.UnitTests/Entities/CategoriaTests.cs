using CentavoControl.Domain.Entities;
using CentavoControl.Domain.Enums;
using CentavoControl.UnitTests.Common;
using FluentAssertions;

namespace CentavoControl.UnitTests.Entities;

public class CategoriaTests
{
    [Fact]
    public void CriarCategoria_ComNomeVazio_DeveAdicionarNotificacao()
    {
        var categoria = new Categoria("", "Descricao teste");

        categoria.IsValid.Should().BeFalse();
        categoria.Notifications.Should().Contain(x => x.Message.Contains("obrigatório"));
    }

    [Fact]
    public void AdicionarTransacao_Valida_DeveIncluirNaColecao()
    {
        var usuario = TestDataFactory.CreateUsuario();
        var conta = TestDataFactory.CreateConta(usuario);
        var categoria = new Categoria("Lazer");
        var transacao = new Transacao(40m, DateTime.Today, "Cinema", TipoTransacao.Despesa, conta.Id);

        categoria.AdicionarTransacao(transacao);

        categoria.Transacoes.Should().ContainSingle();
        categoria.IsValid.Should().BeTrue();
    }

    [Fact]
    public void AdicionarTransacao_Nula_DeveAdicionarNotificacao()
    {
        var categoria = new Categoria("Transporte");

        categoria.AdicionarTransacao(null);

        categoria.IsValid.Should().BeFalse();
        categoria.Notifications.Should().Contain(x => x.Message.Contains("Transação inválida"));
    }
}

