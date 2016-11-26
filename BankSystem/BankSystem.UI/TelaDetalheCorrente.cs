using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.Core;

namespace BankSystem.UI
{
    public class TelaDetalheContaPoupanca : TelaDetalheConta
    {
        public void Print(ContaPoupanca conta)
        {
            while (true)
            {
                PrintExtrato(conta);
                PrintMenu(conta);
            }
        }

        protected  void PrintMenu(ContaCorrente conta)
        {
            Console.WriteLine("S - Saque | D - Deposito | P - Pagamento");
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.S:
                    DigitarValor((x) => conta.Sacar(x));
                    break;
                case ConsoleKey.D:
                    DigitarValor((x) => conta.Sacar(x));
                    break;
                case ConsoleKey.P:
                    DigitarValor((x) => conta.Sacar(x));
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
    }
}
}
