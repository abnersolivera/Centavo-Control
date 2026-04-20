using CentavoControl.Domain.Entities;
using CentavoControl.UnitTests.Common;
using FluentAssertions;

namespace CentavoControl.UnitTests.Entities;

public class UsuarioTests
{
    [Fact]
    public void AdicionarConta_ComUsuarioCorreto_DeveAdicionarConta()
    {
        var usuario = TestDataFactory.CreateUsuario();
        var conta = new Conta("Conta Salario", usuario.Id, 0m, 0m);

        usuario.AdicionarConta(conta);

        usuario.Contas.Should().ContainSingle();
        usuario.IsValid.Should().BeTrue();
    }

    [Fact]
    public void AdicionarConta_ComOutroUsuario_DeveAdicionarNotificacao()
    {
        var usuario = TestDataFactory.CreateUsuario();
        var outro = TestDataFactory.CreateUsuario("Maria", "maria@teste.com");
        var conta = new Conta("Conta Maria", outro.Id, 0m, 0m);

        usuario.AdicionarConta(conta);

        usuario.Contas.Should().BeEmpty();
        usuario.IsValid.Should().BeFalse();
        usuario.Notifications.Should().Contain(x => x.Message.Contains("não pertence"));
    }

    [Fact]
    public void AdicionarCartao_ComUsuarioCorreto_DeveAdicionarCartao()
    {
        var usuario = TestDataFactory.CreateUsuario();
        var cartao = TestDataFactory.CreateCartao(usuario);

        usuario.AdicionarCartao(cartao);

        usuario.Cartoes.Should().ContainSingle();
        usuario.IsValid.Should().BeTrue();
    }

    [Fact]
    public void AdicionarCartao_Nulo_DeveAdicionarNotificacao()
    {
        var usuario = TestDataFactory.CreateUsuario();

        usuario.AdicionarCartao(null!);

        usuario.IsValid.Should().BeFalse();
        usuario.Notifications.Should().Contain(x => x.Message.Contains("Cartão inválido"));
    }
}

