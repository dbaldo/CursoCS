using BankSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.UI
{
    public class TelaConta
    {
        enum OpPrincipal { CriarConta, DetalheConta };
        public static List<ContaBancaria> _listContas = new List<ContaBancaria>();


        public void Iniciar()
        {
            ListAll();

            var ret = MenuPrincipal();
            if (ret == OpPrincipal.CriarConta)
            {
                CriarNovaConta();
            }
            else
            {
                ExibirConta();
            }
        }

        void CriarNovaConta()
        {
            throw new NotImplementedException();
        }

        void ExibirConta()
        {
            throw new NotImplementedException();
        }

        OpPrincipal MenuPrincipal()
        {
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.N)
            {
                return OpPrincipal.CriarConta;
            }

            return OpPrincipal.DetalheConta;
        }

        void ListAll()
        {
            foreach(var conta in _listContas)
            {
                Console.WriteLine("Conta  Ag.{0} N.{1} - Saldo {2} ", conta.NumeroAgencia, conta.NumeroConta, conta.Saldo);
            }
        }

        void PrintMenuPoupanca(ContaPoupanca conta)
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

        void PrintMenuCorrente(ContaCorrente conta)
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

        void PrintExtrato(ContaBancaria conta)
        {
            foreach (var lancamento in conta.Extrato)
            {
                Console.WriteLine("{0}   {1}   {2}", lancamento.Data, lancamento.Historico, lancamento.Valor);
            }
        }

        void DigitarValor(Action<decimal> act)
        {
            Console.Write("Digite um valor");
            decimal v = decimal.Parse(Console.ReadLine());
            act(v);
        }

    }
}
