namespace BankSystem.Core
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
            Debitar(TipoLancamento.Resgate, valor, "RESGATE POUP");
        }

        public void AcrescentarJuros(decimal juros)
        {
            var calculoJuros = (Saldo * juros);

            Creditar(TipoLancamento.Juros, calculoJuros, "JUROS");

        }

    }
}
