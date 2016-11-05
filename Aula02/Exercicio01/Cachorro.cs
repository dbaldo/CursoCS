using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01
{
    public class Cachorro : Animal
    {
        public override void FazerSom()
        {
            Console.WriteLine("Cachorro {0} => Au! Au!", Nome);
        }
    }
}
