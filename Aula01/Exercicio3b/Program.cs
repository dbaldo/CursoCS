using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio3b
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Digite o n1: ");
            int n1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o n2: ");
            int n2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o n3: ");
            int n3 = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o n4: ");
            int n4 = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o n5: ");
            int n5 = int.Parse(Console.ReadLine());

            int? numMax = null, numMin = null;

            for (int min=0, max=100; min < max; min++, max--)
            {
                if (numMax == null)
                {
                    if (n1 > max)
                    {
                        numMax = n1;
                    }
                    if (n2 > max)
                    {
                        numMax = n2;
                    }
                    if (n3 > max)
                    {
                        numMax = n3;
                    }
                    if (n4 > max)
                    {
                        numMax = n4;
                    }
                    if (n5 > max)
                    {
                        numMax = n5;
                    }
                }

                if (numMin == null)
                {
                    if (n1 < min)
                    {
                        numMin = n1;
                    }
                    if (n2 < min)
                    {
                        numMin = n2;
                    }
                    if (n3 < min)
                    {
                        numMin = n3;
                    }
                    if (n4 < min)
                    {
                        numMin = n4;
                    }
                    if (n5 < min)
                    {
                        numMin = n5;
                    }
                }
            }

            Console.WriteLine(" min {0} max {1}", numMin, numMax);

        }
    }
}
