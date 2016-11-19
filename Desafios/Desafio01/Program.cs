using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio01
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientePJ = new PessoaJuridica() {CNPJ = "01.000.000/0002-23", Codigo = 1, Nome = "EMPRESA S.A"};
            var clientePF = new PessoaFisica() {CPF = "123.123.444-13", RG = "12.323.442-3", Codigo = 2, Nome = "JOSE DA SILVA"};

            var poupanca = new Poupanca(clientePF);
            poupanca.Depositar(1200m);
            poupanca.Sacar(200m);

            Console.WriteLine("Saldo Poupanca {0:C2}", poupanca.Saldo);

            var contaSalario = new ContaSalario(clientePF);
            contaSalario.Depositar(12000m);
            Console.WriteLine("Saldo Conta Salario  {0:C2}",contaSalario.Saldo);

            var contaCorrente = new ContaCorrente(clientePJ);
            contaCorrente.Depositar(100);
            contaCorrente.Depositar(400);
            contaCorrente.Depositar(500);
            contaCorrente.Depositar(500);

            contaCorrente.Pagar(400, "CONTA LUZ");
            contaCorrente.Sacar(50);
            Console.WriteLine("Saldo Conta Corrente  {0:C2}", contaCorrente.Saldo);

        }
    }
}
