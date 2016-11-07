using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio02
{
    public struct Par<T1, T2>
        where T1: struct
        where T2: struct
    {
        public T1 Valor1;
        public T2 Valor2;

        public void Print()
        {
            Console.WriteLine("Par {0}, {1}", Valor1, Valor2);
        }
    }
}
