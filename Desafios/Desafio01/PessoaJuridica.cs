using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio01
{
    public class PessoaJuridica : ICliente
    {
        public int Codigo
        {
            get;
            set;
        }

        public string Nome
        {
            get;
            set;
        }

        public string CNPJ
        {
            get;
            set;
        }
    }
}
