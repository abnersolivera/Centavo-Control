using CentavoControl.UnitTests.Common;
using FluentAssertions;

namespace CentavoControl.UnitTests.Entities;

public class ContaTests
{
    [Fact]
    public void Creditar_ComValorPositivo_DeveSomarSaldo()
    {
        var usuario = TestDataFactory.CreateUsuario();
        var conta = TestDataFactory.CreateConta(usuario, saldo: 100m);

        conta.Creditar(25m);

        conta.Saldo.Should().Be(125m);
        conta.IsValid.Should().BeTrue();
    }

    [Fact]
    public void Debitar_ComSaldoDisponivel_DeveSubtrairSaldo()
    {
        var usuario = TestDataFactory.CreateUsuario();
        var conta = TestDataFactory.CreateConta(usuario, saldo: 100m, limite: 20m);

        conta.Debitar(110m);

        conta.Saldo.Should().Be(-10m);
        conta.IsValid.Should().BeTrue();
    }

    [Fact]
    public void Debitar_ComValorInvalido_DeveAdicionarNotificacaoENaoAlterarSaldo()
    {
        var usuario = TestDataFactory.CreateUsuario();
        var conta = TestDataFactory.CreateConta(usuario, saldo: 100m);

        conta.Debitar(0m);

        conta.Saldo.Should().Be(100m);
        conta.IsValid.Should().BeFalse();
        conta.Notifications.Should().Contain(x => x.Message.Contains("débito"));
    }

    [Fact]
    public void Debitar_SemSaldoDisponivel_DeveAdicionarNotificacao()
    {
        var usuario = TestDataFactory.CreateUsuario();
        var conta = TestDataFactory.CreateConta(usuario, saldo: 10m, limite: 0m);

        conta.Debitar(20m);

        conta.Saldo.Should().Be(10m);
        conta.IsValid.Should().BeFalse();
        conta.Notifications.Should().Contain(x => x.Message.Contains("Saldo insuficiente"));
    }
}

