using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio01
{
    public abstract class Conta
    {
        private readonly List<Lancamento> _innerLancamentos = new List<Lancamento>();

        protected Conta(ICliente cliente)
        {
            this.Cliente = cliente;
        }

        public int Codigo
        {
            get;
            set;
        }

        public ICliente Cliente
        {
            get;
            protected set;
        }

        public virtual decimal Saldo
        {
            get
            {
                return _innerLancamentos.Sum(x => x.Valor);
            }
        }

        public IEnumerable<Lancamento> Lancamentos
        {
            get
            {
                return _innerLancamentos;
            }
        }

        public virtual void Sacar(decimal valor)
        {
            _innerLancamentos.Add(new Lancamento()
            {
                Data = DateTime.Now,
                Historico = "SAQUE",
                Tipo = TipoLancamento.Saque,
                Valor = -valor
            }); 
        }

        public virtual void Depositar(decimal valor)
        {
            _innerLancamentos.Add(new Lancamento()
            {
                Data = DateTime.Now,
                Historico = "DEPOSITO",
                Tipo = TipoLancamento.Deposito,
                Valor = valor
            });
        }

        public virtual void Pagar(decimal valor, string historico)
        {
            _innerLancamentos.Add(new Lancamento()
            {
                Data = DateTime.Now,
                Historico = "PG " + historico,
                Tipo = TipoLancamento.Deposito,
                Valor = -valor
            });
        }
    }
}
