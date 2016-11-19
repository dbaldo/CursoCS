using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio02
{
    public class EntradaSaida
    {

        public EntradaSaida(Veiculo veiculo, TipoServico servico)
        {
            this.DataEntrada = DateTime.Now;
            this.Veiculo = veiculo;

            this.Lavagem = new Lavagem() { Categoria = veiculo.Categoria, Servico = servico }; //Buscar no repositorios
        }

        public int Id
        {
            get;
            set;
        }


        public DateTime DataEntrada
        {
            get;
            set;
        }

        public Nullable<DateTime> DataSaida
        {
            get;
            set;
        }

        public Veiculo Veiculo
        {
            get;
            set;
        }

        public Lavagem Lavagem
        {
            get;
            set;
        }

        public Operador Operador
        {
            get;
            set;
        }

        public decimal ValorCobrado
        {
            get;
            set;
        }

        public void Sair()
        {
            this.DataSaida = DateTime.Now;
            this.ValorCobrado = Lavagem.Valor;
        }
    }
}
