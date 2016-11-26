using BankSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.UI
{
    public abstract class TelaDetalheConta
    { 

        protected void PrintExtrato(ContaBancaria conta)
        {
            foreach(var lancamento in conta.Extrato)
            {
                Console.WriteLine("{0}   {1}   {2}", lancamento.Data, lancamento.Historico, lancamento.Valor);
            }
        }

        protected void DigitarValor(Action<decimal> act)
        {
            Console.Write("Digite um valor");
            decimal v = decimal.Parse(Console.ReadLine());
            act(v);
        }


    }
}
