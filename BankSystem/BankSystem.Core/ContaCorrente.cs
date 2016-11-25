namespace BankSystem.Core
{
    public class ContaCorrente : ContaBancaria
    {
        public ContaCorrente(Cliente cliente, int numConta, int numAgencia)
            :base(cliente, numConta, numAgencia)
        {
        }

        public void Sacar(decimal valor)
        {
            Debitar(TipoLancamento.Saque, valor, "SAQUE");
        }

        public void Depositar(decimal valor)
        {
            Creditar(TipoLancamento.Deposito, valor, "DEPOSITO");
        }

        public void Pagar(decimal valor)
        {
            Debitar(TipoLancamento.Pagamento, valor, "PAGAMENTO");
        }

    }
}
