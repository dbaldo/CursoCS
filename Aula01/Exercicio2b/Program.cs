using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio2b
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite seu peso terrestre: ");
            float pt = float.Parse(Console.ReadLine());

            //calculando o peso lunar
            float pl = (pt*0.17f);

            if (pl > 20)
            {
                Console.WriteLine("{0} => seu peso lunar é maior 20kg", pl);
            }
            else if (pl < 20)
            {
                Console.WriteLine("{0} => seu peso lunar é menor a 20kg", pl);
            }
            else
            {
                Console.WriteLine("{0} => seu peso lunar é igual a 20kg", pl);                
            }

        }
    }
}
