using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Core
{
    public class ContaBancaria
    {

        public ContaBancaria(Cliente cliente, int numConta, int numAgencia )
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

        public void Debitar(decimal valor, string historico)
        {

            CheckBloqueio();
            CheckValor(valor);

            if (Saldo < valor)
                throw new InvalidOperationException("Conta sem Saldo");


            this.Saldo -= valor;
        }


        public void Creditar(decimal valor, string historico)
        {
            CheckBloqueio();
            CheckValor(valor);

            this.Saldo += valor;
        }

        public void Transferir(ContaBancaria outraconta, decimal valor)
        {
            this.Debitar(valor, String.Format("TRANSF PARA {0}-{1}", outraconta.NumeroAgencia, outraconta.NumeroConta));
            outraconta.Creditar(valor, String.Format("TRANSF DE {0}-{1}", this.NumeroAgencia, this.NumeroConta));
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
    }
}
