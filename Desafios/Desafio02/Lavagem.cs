using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio02
{
    public class Lavagem
    {
        public int Id
        {
            get;
            set;
        }

        public TipoServico Servico
        {
            get;
            set;
        }

        public Categoria Categoria
        {
            get;
            set;
        }

        public decimal Valor
        {
            get;
            set;
        }
    }
}
