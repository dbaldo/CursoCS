using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01
{
    class Program
    {

        static void Main(string[] args)
        {
            Animal[] animais =
            {
                new Cachorro() {Nome = "Toto"},
                new Cachorro() {Nome = "Rex"},
                new Gato() {Nome = "Garfield"},
                new Galinha() {Nome = "Filomena"}
            };

            for (int i = 0; i < animais.Length; i++)
            {
                animais[i].FazerSom();
            }

        }

    }
}
