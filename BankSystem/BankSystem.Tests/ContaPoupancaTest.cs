using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankSystem.Core;
using System.Linq;

namespace BankSystem.Tests
{
    [TestClass]
    public class ContaPoupancaTest
    {
        [TestInitialize]
        public void Setup()
        {
            ClienteDeTeste = new Cliente() { TipoDoc = Cliente.TipoDocumento.CPF, NumeroDoc = "111.233.333-12", Nome = "TESTE" };
        }

        public Cliente ClienteDeTeste
        {
            get;
            set;

        }
        [TestMethod]
        public void Poupanca_QuandoAplicarValor_DeveAplicarSaldo()
        {
            //ARRANGE
            ContaPoupanca conta = new ContaPoupanca(ClienteDeTeste, 1, 1000);

            //ACT
            conta.Aplicar(50);

            //ASSERT
            Assert.AreEqual(50, conta.Saldo);
            Assert.AreEqual(TipoLancamento.Aplicacao, conta.Extrato.Last().Tipo);
            Assert.AreEqual(50, conta.Extrato.Last().Valor);
        }

        [TestMethod]
        public void Poupanca_QuandoResgatarValor_DeveResgatarSaldo()
        {
            //ARRANGE
            ContaPoupanca conta = new ContaPoupanca(ClienteDeTeste, 1, 1000);
            conta.Aplicar(50);

            //ACT
            conta.Resgatar(50);

            //ASSERT
            Assert.AreEqual(0, conta.Saldo);
            Assert.AreEqual(TipoLancamento.Resgate, conta.Extrato.Last().Tipo);
            Assert.AreEqual(-50, conta.Extrato.Last().Valor);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Conta Bloqueada")]
        public void Poupanca_QuandoAplicarBloqueado_DeveErro()
        {
            //ARRANGE
            ContaPoupanca conta = new ContaPoupanca(ClienteDeTeste, 1, 1000);
            conta.Bloqueada = true;

            //ACT
            conta.Aplicar(50);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Conta Bloqueada")]
        public void Poupanca_QuandoResgatarBloqueado_DeveErro()
        {
            //ARRANGE
            ContaPoupanca conta = new ContaPoupanca(ClienteDeTeste, 1, 1000);
            conta.Bloqueada = true;

            //ACT
            conta.Resgatar(50);
        }

        [TestMethod]
        public void Poupanca_QuandoTransferirValor_DeveTransferirSaldo()
        {
            //ARRANGE
            var conta1001 = new ContaPoupanca(ClienteDeTeste, 1, 1001);
            var conta2001 = new ContaCorrente(ClienteDeTeste, 1, 2001);
            conta1001.Aplicar(50);

            //ACT
            conta1001.Transferir(conta2001, 50);

            //ASSERT 
            Assert.AreEqual(0, conta1001.Saldo);
            Assert.AreEqual(50, conta2001.Saldo);

            Assert.AreEqual(TipoLancamento.Transferencia, conta1001.Extrato.Last().Tipo);
            Assert.AreEqual(TipoLancamento.Transferencia, conta2001.Extrato.Last().Tipo);

            Assert.AreEqual(-50, conta1001.Extrato.Last().Valor);
            Assert.AreEqual(50, conta2001.Extrato.Last().Valor);
        }

        [TestMethod]
        public void Poupanca_QuandoAcrescentarJuros_AtualizarSaldo()
        {
            //ARRANGE
            var conta1001 = new ContaPoupanca(ClienteDeTeste, 1, 1001);
            conta1001.Aplicar(100);

            //ACT
            conta1001.AcrescentarJuros(0.01m);

            //ASSERT
            Assert.AreEqual(101, conta1001.Saldo);
            Assert.AreEqual(TipoLancamento.Juros, conta1001.Extrato.Last().Tipo);
            Assert.AreEqual(1, conta1001.Extrato.Last().Valor);
        }



    }
}
