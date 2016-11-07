using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Exercicio04
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();

            Console.WriteLine("Entre com uma lista de números :");

            //Entrando com a lista de números 
            while (true)
            {
                string textoDigitado = Console.ReadLine();

                int numero;
                if (int.TryParse(textoDigitado, out numero))
                {
                    list.Add(numero);
                }
                else if(textoDigitado != "")
                {
                    Console.WriteLine("Número inválido! Entre novamente");
                }
                if (textoDigitado == "")
                {
                    break;
                }
            }

            //Ordenando os numeros
            list.Sort(new ComparadorNumero());

            //Exibindo
            Console.Write("Valores ordenados :");
            foreach (var numero in list)
            {
                Console.Write("{0} ", numero);
            }

            Console.WriteLine();

        }

        class ComparadorNumero : IComparer<int>
        {
            /// <summary>
            /// Retorna 1, se x for maior que y
            /// Retorna -1, se x for menor que y
            /// Retorna 0, se forem iguais
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare(int x, int y)
            {
                return x.CompareTo(y);
            }
        }

    }
}
