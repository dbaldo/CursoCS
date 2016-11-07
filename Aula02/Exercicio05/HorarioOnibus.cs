using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio05
{
    public struct HorarioOnibus
    {
        public HorarioOnibus(TimeSpan hora, int linha)
            :this()
        {
            this.Hora = hora;
            this.NumeroLinha = linha;
        }

        public TimeSpan Hora { get; set; }
        public int NumeroLinha { get; set; }
    }
}
