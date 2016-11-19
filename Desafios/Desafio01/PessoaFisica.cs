using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio01
{
    public class PessoaFisica : ICliente
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

        public string RG
        {
            get;
            set;
        }

        public string CPF
        {
            get;
            set;
        }
    }
}
