using System;

namespace CentavoControl.Domain.Entities
{
    public class Transacao : Entity
    {
        public decimal Valor { get; private set; }
        public DateTime Data { get; private set; }
        public string Descricao { get; private set; }
        public Enums.TipoTransacao Tipo { get; private set; }

        public Transacao(decimal valor, DateTime data, string descricao, Enums.TipoTransacao tipo)
        {
            Valor = valor;
            Data = data;
            Descricao = descricao;
            Tipo = tipo;
        }
    }
}
