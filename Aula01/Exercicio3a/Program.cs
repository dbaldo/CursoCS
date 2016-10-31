using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio3a
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o n1 ");
            int n1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o n2 ");
            int n2 = int.Parse(Console.ReadLine());

            if (n1 > n2)
            {
                int aux = n1;
                n1 = n2;
                n2 = aux;
            }

            Console.WriteLine("n1 {0} n2 {1} ", n1, n2);
        }
    }
}
