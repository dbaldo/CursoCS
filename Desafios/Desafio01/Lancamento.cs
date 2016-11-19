using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio01
{
    public struct Lancamento
    {
        public DateTime Data { get; set; }
        public string Historico { get; set; }
        public TipoLancamento Tipo { get; set; }
        public decimal Valor { get; set; }
    }
}
