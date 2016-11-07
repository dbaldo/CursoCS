using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio03
{
    class Program
    {
        private static void Main(string[] args)
        {
            var list = new List<int> {19, -10, 12, -6, -3, 34, -2, 5};
            foreach (var i in list.ToArray())
            {
                if (i < 0)
                {
                    list.Remove(i);
                }
            }

            Console.Write("Números positivos : ");
            foreach (var j in list)
            {
                Console.Write("{0} ", j);
            }
            Console.WriteLine();
        }
    }
}
