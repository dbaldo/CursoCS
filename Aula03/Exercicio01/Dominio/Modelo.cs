using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Modelo
    {
        public int Id
        {
            get;
            set;
        }

        public int Nome
        {
            get;
            set;
        }

        public Marca Marca
        {
            get;
            set;
        }
    }
}
