using BankSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.UI
{
    public class TelaDetalhePoupanca : TelaDetalheConta
    {
        public void Print(ContaPoupanca conta)
        {
            while (true)
            {
                PrintExtrato(conta);
                PrintMenu(conta);
            }
        }

        protected void PrintMenu(ContaPoupanca conta)
        {
            Console.WriteLine("A - Aplicacao | R - Resgate ");
            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.A:
                    DigitarValor((x) => conta.Aplicar(x));
                    break;
                case ConsoleKey.R:
                    DigitarValor((x) => conta.Resgatar(x));
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;

            }
        }
    }
}
