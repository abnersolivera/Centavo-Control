using CentavoControl.UnitTests.Common;
using FluentAssertions;

namespace CentavoControl.UnitTests.Entities;

public class CartaoCreditoTests
{
    [Fact]
    public void UtilizarLimite_ComValorValido_DeveAtualizarLimiteUtilizado()
    {
        var usuario = TestDataFactory.CreateUsuario();
        var cartao = TestDataFactory.CreateCartao(usuario, limite: 1000m);

        cartao.UtilizarLimite(300m);

        cartao.LimiteUtilizado.Should().Be(300m);
        cartao.ObterSaldoDisponivel().Should().Be(700m);
        cartao.IsValid.Should().BeTrue();
    }

    [Fact]
    public void UtilizarLimite_ComValorMaiorQueDisponivel_DeveAdicionarNotificacao()
    {
        var usuario = TestDataFactory.CreateUsuario();
        var cartao = TestDataFactory.CreateCartao(usuario, limite: 100m);

        cartao.UtilizarLimite(150m);

        cartao.LimiteUtilizado.Should().Be(0m);
        cartao.IsValid.Should().BeFalse();
        cartao.Notifications.Should().Contain(x => x.Message.Contains("Limite insuficiente"));
    }

    [Fact]
    public void LiberarLimite_DeveReduzirLimiteUtilizado()
    {
        var usuario = TestDataFactory.CreateUsuario();
        var cartao = TestDataFactory.CreateCartao(usuario, limite: 1000m);
        cartao.UtilizarLimite(400m);

        cartao.LiberarLimite(150m);

        cartao.LimiteUtilizado.Should().Be(250m);
    }
}

