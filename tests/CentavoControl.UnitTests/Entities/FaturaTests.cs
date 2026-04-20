using CentavoControl.Domain.Entities;
using CentavoControl.Domain.Enums;
using CentavoControl.UnitTests.Common;
using FluentAssertions;

namespace CentavoControl.UnitTests.Entities;

public class FaturaTests
{
    [Fact]
    public void AdicionarTransacao_DeveRecalcularValorTotal()
    {
        var usuario = TestDataFactory.CreateUsuario();
        var conta = TestDataFactory.CreateConta(usuario);
        var cartao = TestDataFactory.CreateCartao(usuario);
        var fatura = new Fatura(cartao, DateTime.Today, DateTime.Today.AddDays(10), 0m);

        var t1 = new Transacao(100m, DateTime.Today, "Compra 1", TipoTransacao.Despesa, conta.Id);
        var t2 = new Transacao(50m, DateTime.Today, "Compra 2", TipoTransacao.Despesa, conta.Id);

        fatura.AdicionarTransacao(t1);
        fatura.AdicionarTransacao(t2);

        fatura.ValorTotal.Should().Be(150m);
        fatura.Transacoes.Should().HaveCount(2);
    }

    [Fact]
    public void AdicionarTransacao_Nula_DeveAdicionarNotificacao()
    {
        var usuario = TestDataFactory.CreateUsuario();
        var cartao = TestDataFactory.CreateCartao(usuario);
        var fatura = new Fatura(cartao, DateTime.Today, DateTime.Today.AddDays(10), 0m);

        fatura.AdicionarTransacao(null!);

        fatura.IsValid.Should().BeFalse();
        fatura.Notifications.Should().Contain(x => x.Message.Contains("Transação inválida"));
    }

    [Fact]
    public void Pagar_DeveMarcarFaturaComoPaga()
    {
        var usuario = TestDataFactory.CreateUsuario();
        var cartao = TestDataFactory.CreateCartao(usuario);
        var fatura = new Fatura(cartao, DateTime.Today, DateTime.Today.AddDays(10), 0m);

        fatura.Pagar();

        fatura.Paga.Should().BeTrue();
    }
}

