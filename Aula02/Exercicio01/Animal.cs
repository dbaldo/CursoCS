using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01
{
    public abstract class Animal
    {
        public enum EnumSexo { Macho, Femea }

        public int Idade { get; set; }
        public string Nome { get; set; }
        public EnumSexo Sexo { get; set; }

        public abstract void FazerSom();

    }
}
