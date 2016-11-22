using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio02
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa pessoa = new Pessoa() { Nome = "João", Sobrenome = "Silva" };

            Console.WriteLine(" exibir  = {0} ", pessoa.Exibir((p) => p.Nome + " " + p.Sobrenome));

            Console.WriteLine(" exibir  = {0} ", pessoa.Exibir((p) => p.Sobrenome + ", " + p.Nome));
        }
    }
}
