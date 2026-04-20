using CentavoControl.Domain.Enums;

namespace CentavoControl.Domain.Entities
{
    public class Transacao : Entity
    {
        public decimal Valor { get; private set; }
        public DateTime Data { get; private set; }
        public string Descricao { get; private set; }
        public TipoTransacao Tipo { get; private set; }
        public TipoRecorrencia Recorrencia { get; private set; }
        public int? Parcelas { get; private set; }
        public int? ParcelaAtual { get; private set; }
        public DateTime? DataProximaOcorrencia { get; private set; }
        public Guid ContaId { get; private set; }
        public Guid? CartaoCreditoId { get; private set; }
        public Guid? CategoriaId { get; private set; }
        public Conta? Conta { get; private set; }
        public CartaoCredito? CartaoCredito { get; private set; }
        public Categoria? Categoria { get; private set; }

        public Transacao(
            decimal valor,
            DateTime data,
            string descricao,
            TipoTransacao tipo,
            Guid contaId,
            TipoRecorrencia recorrencia = TipoRecorrencia.Pontual,
            Guid? categoriaId = null,
            Guid? cartaoCreditoId = null,
            int? parcelas = null
        )
        {
            if (valor <= 0)
                AddNotification("Valor da transação deve ser maior que zero.");

            if (parcelas.HasValue && parcelas.Value <= 0)
                AddNotification("Número de parcelas deve ser maior que zero.");

            Valor = valor;
            Data = data;
            Descricao = descricao;
            Tipo = tipo;
            Recorrencia = recorrencia;
            ContaId = contaId;
            CategoriaId = categoriaId;
            CartaoCreditoId = cartaoCreditoId;
            Parcelas = parcelas ?? (recorrencia == TipoRecorrencia.Pontual ? 1 : null);
            ParcelaAtual = parcelas.HasValue ? 1 : null;
        }
    }
}
