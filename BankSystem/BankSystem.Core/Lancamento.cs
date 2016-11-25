using System;

namespace BankSystem.Core
{

    public enum TipoLancamento { Saque, Deposito, Transferencia, Pagamento, Juros, Aplicacao, Resgate }

    public struct  Lancamento
    {

        public DateTime Data { get; set; }

        public TipoLancamento Tipo { get; set; }

        public decimal Valor { get; set; }

        public string Historico { get; set; }

    }
}
