using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio02
{
    public class Pessoa : IEquatable<Pessoa>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get; set; }

        public IEnumerable<string> Filhos { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Pessoa))
                return false;

            return Equals((Pessoa)obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public bool Equals(Pessoa other)
        {
            return other.Nome == this.Nome;
        }
    }
}
