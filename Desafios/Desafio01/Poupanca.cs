using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio01
{
    public class Poupanca : Conta
    {
        public Poupanca(ICliente cliente)
            :base(cliente)
        {

        }

        public override decimal Saldo
        {
            get
            {
                return AcrescerJuros(base.Saldo);
            }
        }

        private decimal AcrescerJuros(decimal p)
        {
            return p*(1m+((0.5m/30.00m)*DateTime.Now.Day));
        }
    }
}
