using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio02
{
    public class Operador
    {
        public int Id
        {
            get;
            set;
        }

        public string Nome
        {
            get;
            set;
        }

        public string Login
        {
            get;
            set;
        }

        public EntradaSaida RegistrarEntrada(Veiculo veiculo, TipoServico servico)
        {
            return new EntradaSaida(veiculo, servico);
        }
    }
}
