using CentavoControl.Domain.Entities;
using CentavoControl.Domain.Enums;
using CentavoControl.UnitTests.Common;
using FluentAssertions;

namespace CentavoControl.UnitTests.Entities;

public class TransacaoTests
{
    [Fact]
    public void CriarTransacao_Valida_DevePreencherCampos()
    {
        var usuario = TestDataFactory.CreateUsuario();
        var conta = TestDataFactory.CreateConta(usuario);

        var transacao = new Transacao(120m, DateTime.Today, "Mercado", TipoTransacao.Despesa, conta.Id);

        transacao.Valor.Should().Be(120m);
        transacao.Tipo.Should().Be(TipoTransacao.Despesa);
        transacao.Recorrencia.Should().Be(TipoRecorrencia.Pontual);
        transacao.ContaId.Should().Be(conta.Id);
        transacao.IsValid.Should().BeTrue();
    }

    [Fact]
    public void CriarTransacao_ComValorInvalido_DeveAdicionarNotificacao()
    {
        var usuario = TestDataFactory.CreateUsuario();
        var conta = TestDataFactory.CreateConta(usuario);

        var transacao = new Transacao(0m, DateTime.Today, "Teste", TipoTransacao.Receita, conta.Id);

        transacao.IsValid.Should().BeFalse();
        transacao.Notifications.Should().Contain(x => x.Message.Contains("maior que zero"));
    }

    [Fact]
    public void CriarTransacao_ComParcelas_DeveIniciarParcelaAtualComUm()
    {
        var usuario = TestDataFactory.CreateUsuario();
        var conta = TestDataFactory.CreateConta(usuario);

        var transacao = new Transacao(500m, DateTime.Today, "Notebook", TipoTransacao.Despesa, conta.Id, parcelas: 10);

        transacao.Parcelas.Should().Be(10);
        transacao.ParcelaAtual.Should().Be(1);
        transacao.IsValid.Should().BeTrue();
    }
}

