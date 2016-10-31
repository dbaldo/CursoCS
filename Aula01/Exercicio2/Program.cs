using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite um numero: ");
            int n = int.Parse(Console.ReadLine());

            if (n%2 == 0)
            {
                Console.WriteLine("{0} é par", n);
            }
            else
            {
                Console.WriteLine("{0} é impar", n);
            }

        }
    }
}
