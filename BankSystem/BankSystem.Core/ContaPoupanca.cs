﻿namespace BankSystem.Core
{
    public class ContaPoupanca : ContaBancaria
    {
        public ContaPoupanca(Cliente cliente, int numConta, int numAgencia)
            :base(cliente, numConta, numAgencia)
        {
        }

        public void Aplicar(decimal valor)
        {
            Creditar(TipoLancamento.Aplicacao, valor, "APLICACAO POUP");
        }

        public void Resgatar(decimal valor)
        {
            Creditar(TipoLancamento.Resgate, valor, "RESGATE POUP");
        }

        public void AcrescentarJuros(decimal juros)
        {
            var calculoJuros = (Saldo * (1m + juros));

            Creditar(TipoLancamento.Juros, (Saldo * (1m + juros)), "JUROS");
        }

    }
}
