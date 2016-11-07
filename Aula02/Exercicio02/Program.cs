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
            var par1 = new Par<char, int>();
            par1.Valor1 = 'A';
            par1.Valor2 = 12313;

            par1.Print();

        }
    }
}
