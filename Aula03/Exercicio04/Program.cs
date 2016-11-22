using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio04
{
    class Program
    {
        static void Main(string[] args)
        {

            var n1 = 10;
            Console.WriteLine("{0} => {1}",n1 , n1.IsPrime());

            var n2 = 7;
            Console.WriteLine("{0} => {1}",n2, n2.IsPrime());

            var n3 = 1231517;
            Console.WriteLine("{0} => {1}", n3, n3.IsPrime());

        }
    }
}
