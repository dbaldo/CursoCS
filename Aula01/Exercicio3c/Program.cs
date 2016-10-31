using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio3c
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o limite da seq. fibonacci: ");
            int n = int.Parse(Console.ReadLine());

            Fibonacci(n);
        }

        static void Fibonacci(int numero)
        {
            int sum = 1;
            int ant1 = 0;
            int ant2 = 1;

            while (sum <= numero)
            {
                Console.WriteLine(sum);

                sum = ant1 + ant2;
                ant1 = ant2;
                ant2 = sum;
            }
        }
    }
}
