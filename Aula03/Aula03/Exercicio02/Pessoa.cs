using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio02
{
    public class Pessoa
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Exibir(Func<Pessoa, string> del)
        {
            return del(this);
        }
    }
}
