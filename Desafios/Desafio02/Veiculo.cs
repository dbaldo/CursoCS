using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio02
{
    public class Veiculo
    {
        public int Id
        {
            get;
            set;
        }

        public Categoria Categoria
        {
            get;
            set;
        }

        public Modelo Modelo
        {
            get;
            set;
        }

        public string Placa
        {
            get;
            set;
        }
    }
}
