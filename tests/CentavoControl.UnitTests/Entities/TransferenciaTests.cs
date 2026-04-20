using CentavoControl.Domain.Entities;
using CentavoControl.UnitTests.Common;
using FluentAssertions;

namespace CentavoControl.UnitTests.Entities;

public class TransferenciaTests
{
    [Fact]
    public void CriarTransferencia_ComMesmaConta_DeveAdicionarNotificacao()
    {
        var usuario = TestDataFactory.CreateUsuario();
        var conta = TestDataFactory.CreateConta(usuario);

        var transferencia = new Transferencia(usuario.Id, conta.Id, conta.Id, 50m, DateTime.Today);

        transferencia.IsValid.Should().BeFalse();
        transferencia.Notifications.Should().Contain(x => x.Message.Contains("não podem ser iguais"));
    }

    [Fact]
    public void CriarTransferencia_ComValorInvalido_DeveAdicionarNotificacao()
    {
        var usuario = TestDataFactory.CreateUsuario();
        var origem = TestDataFactory.CreateConta(usuario, saldo: 100m);
        var destino = new Conta("Destino", usuario.Id, 0m, 0m);

        var transferencia = new Transferencia(usuario.Id, origem.Id, destino.Id, 0m, DateTime.Today);

        transferencia.IsValid.Should().BeFalse();
        transferencia.Notifications.Should().Contain(x => x.Message.Contains("maior que zero"));
    }

    [Fact]
    public void ValidarSaldoDisponivel_ComContaSemSaldo_DeveRetornarFalso()
    {
        var usuario = TestDataFactory.CreateUsuario();
        var origem = TestDataFactory.CreateConta(usuario, saldo: 10m, limite: 0m);
        var destino = new Conta("Destino", usuario.Id, 0m, 0m);
        var transferencia = new Transferencia(usuario.Id, origem.Id, destino.Id, 50m, DateTime.Today);

        var resultado = transferencia.ValidarSaldoDisponivel(origem);

        resultado.Should().BeFalse();
        transferencia.Notifications.Should().Contain(x => x.Message.Contains("Saldo insuficiente"));
    }

    [Fact]
    public void ValidarSaldoDisponivel_ComSaldoSuficiente_DeveRetornarVerdadeiro()
    {
        var usuario = TestDataFactory.CreateUsuario();
        var origem = TestDataFactory.CreateConta(usuario, saldo: 200m, limite: 0m);
        var destino = new Conta("Destino", usuario.Id, 0m, 0m);
        var transferencia = new Transferencia(usuario.Id, origem.Id, destino.Id, 50m, DateTime.Today);

        var resultado = transferencia.ValidarSaldoDisponivel(origem);

        resultado.Should().BeTrue();
    }
}

