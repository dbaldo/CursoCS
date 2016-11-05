using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01
{
    public class Gato : Animal
    {
        public override void FazerSom()
        {
            Console.WriteLine("Gato {0} => Miau Miau", Nome);
        }
    }
}
