using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankSystem.Core;

namespace BankSystem.Tests
{
    [TestClass]
    public class ContaCorrenteTest
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
        public void QuandoDepositar_DeveCreditarSaldo()
        {
            //Arrange
            var conta = new ContaCorrente(ClienteDeTeste, 1, 1001);

            //Act
            conta.Depositar(50);

            //Assert
            Assert.AreEqual(50, conta.Saldo);
            Assert.AreEqual(TipoLancamento.Deposito, conta.Extrato.Last().Tipo);
            Assert.AreEqual(50, conta.Extrato.Last().Valor);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Conta Bloqueada")]
        public void QuandoDepositarContaBloqueada_LancarExcecao()
        {
            //Arrange
            var conta = new ContaCorrente(ClienteDeTeste, 1, 1001);
            conta.Bloqueada = true;

            //Act
            conta.Depositar(50);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Conta Bloqueada")]
        public void QuandoSacarContaBloqueada_LancarExcecao()
        {
            //Arrange
            var conta = new ContaCorrente(ClienteDeTeste, 1, 1001);
            conta.Depositar(100);
            conta.Bloqueada = true;

            //Act
            conta.Sacar(50);
        }

        [Ignore]
        [TestMethod]
        public void QuandoSacar_DeveDebitarSaldo()
        {
            //ARRANGE
            //ACT
            //ASSERT
        }

        [Ignore]
        [TestMethod]
        public void QuandoTentarSacarSemSaldo_DeveLancarExcecao()
        {
            //ARRANGE
            //ACT
            //ASSERT
        }

        [TestMethod]
        public void QuandoTransferir50_DeveTransferirSaldo()
        {
            //ARRANGE
            var conta1 = new ContaCorrente(ClienteDeTeste, 1, 1);
            var conta2 = new ContaCorrente(ClienteDeTeste, 2, 1);

            //ACT
            conta1.Transferir(conta2, 50);

            //ASSERT
            Assert.AreEqual(0, conta1.Saldo);
            Assert.AreEqual(50, conta2.Saldo);

            Assert.AreEqual(TipoLancamento.Transferencia, conta1.Extrato.Last().Tipo);
            Assert.AreEqual(-50, conta1.Extrato.Last().Valor);

            Assert.AreEqual(TipoLancamento.Transferencia, conta2.Extrato.Last().Tipo);
            Assert.AreEqual(+50, conta2.Extrato.Last().Valor);

        }

    }
}
