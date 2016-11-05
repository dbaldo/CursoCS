using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01
{
    public class Galinha : Animal
    {
        public override void FazerSom()
        {
            Console.WriteLine("Galinha {0} => Có Có Có", Nome);
        }
    }
}
