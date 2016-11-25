using System;
using System.Collections;
using System.Collections.Generic;

namespace BankSystem.Core
{
    public abstract class ContaBancaria
    {
        private readonly List<Lancamento> _listLancamentos = new List<Lancamento>();

        public ContaBancaria(Cliente cliente, int numConta, int numAgencia)
        {
            this.ClienteDaConta = cliente;
            this.NumeroAgencia = numAgencia;
            this.NumeroConta = numConta;
        }

        public Cliente ClienteDaConta
        {
            get;
            protected set;
        }

        public int NumeroConta
        {
            get;
            protected set;
        }

        public int NumeroAgencia
        {
            get;
            set;
        }
            
        public decimal Saldo
        {
            get;
            set;
        }

        public bool Bloqueada
        {
            get;
            set;
        }

        public IEnumerable<Lancamento> Extrato
        {
            get
            {
                return _listLancamentos;
            }
        }

        protected void Debitar(TipoLancamento tipo, decimal valor, string historico)
        {

            CheckBloqueio();
            CheckValor(valor);

            if (Saldo < valor)
                throw new InvalidOperationException("Saldo Insuficiente");

            GravarLancamento(tipo, valor, historico);

            this.Saldo -= valor;
        }

        protected void Creditar(TipoLancamento tipo, decimal valor, string historico)
        {
            CheckBloqueio();
            CheckValor(valor);

            GravarLancamento(tipo, valor, historico);

            this.Saldo += valor;
        }

        public void Transferir(ContaBancaria outraconta, decimal valor)
        {
            this.Debitar(TipoLancamento.Transferencia, valor, String.Format("TRANSF PARA {0}-{1}", outraconta.NumeroAgencia, outraconta.NumeroConta));
            outraconta.Creditar(TipoLancamento.Transferencia, valor, String.Format("TRANSF DE {0}-{1}", this.NumeroAgencia, this.NumeroConta));
        }

        private void CheckValor(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor inválido");
        }

        private void CheckBloqueio()
        {
            if (Bloqueada)
                throw new InvalidOperationException("Conta Bloqueada");
        }

        private void GravarLancamento(TipoLancamento tipo, decimal valor, string historico)
        {
            _listLancamentos.Add(new Lancamento() { Data = DateTime.Now, Historico = historico, Tipo = tipo, Valor = valor });
        }
    }
}
