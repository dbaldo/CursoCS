using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part 1");

            Util.Perform((x) =>
                Console.WriteLine("elem => {0}", x),
                1, 2, 3, 4, 5, 6, 7
                );

            Util.Perform((x) =>
                Console.WriteLine("elem => {0}", x),
                'A','B','C','D','E'
                );


            Console.WriteLine("Part 2");

            var array = new int[] { 3, 6, 2, 7, 8, 10, 1, 4, 5 };

            Array.Sort(array, (x, y) => { 
                var dx = (x % 2);
                var dy = (y % 2);

                if (dx == 1 && dy == 0)
                    return -1;
                else if (dx == 0 && dy == 1)
                    return 1;
                else
                    return 0;
             });

            Array.ForEach(array, (x) => Console.WriteLine("array => {0}", x));

        }
    }
}
