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
        public void ContaCorrente_QuandoDepositar_DeveCreditarSaldo()
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
        public void ContaCorrente_QuandoDepositarContaBloqueada_LancarExcecao()
        {
            //Arrange
            var conta = new ContaCorrente(ClienteDeTeste, 1, 1001);
            conta.Bloqueada = true;

            //Act
            conta.Depositar(50);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Conta Bloqueada")]
        public void ContaCorrente_QuandoSacarContaBloqueada_LancarExcecao()
        {
            //Arrange
            var conta = new ContaCorrente(ClienteDeTeste, 1, 1001);
            conta.Depositar(100);
            conta.Bloqueada = true;

            //Act
            conta.Sacar(50);
        }

        [TestMethod]
        public void ContaCorrente_QuandoSacar_DeveDebitarSaldo()
        {
            //ARRANGE
            var conta = new ContaCorrente(ClienteDeTeste, 1, 1002);
            conta.Depositar(1000);

            //ACT
            conta.Sacar(999);

            //ASSERT
            Assert.AreEqual(1, conta.Saldo);
            Assert.AreEqual(TipoLancamento.Saque, conta.Extrato.Last().Tipo);
            Assert.AreEqual(-999, conta.Extrato.Last().Valor);
        }

        [TestMethod]
        public void ContaCorrente_QuandoPagar_DeveDebitarSaldo()
        {
            //ARRANGE
            var conta = new ContaCorrente(ClienteDeTeste, 1, 1002);
            conta.Depositar(100);

            //ACT
            conta.Pagar(100);

            //ASSERT
            Assert.AreEqual(0, conta.Saldo);
            Assert.AreEqual(TipoLancamento.Pagamento, conta.Extrato.Last().Tipo);
            Assert.AreEqual(-100, conta.Extrato.Last().Valor);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Saldo Insuficiente")]
        public void ContaCorrente_QuandoTentarSacarSemSaldo_DeveLancarExcecao()
        {
            //ARRANGE
            var conta = new ContaCorrente(ClienteDeTeste, 1, 1003);

            //ACT
            conta.Sacar(1);
        }

        [TestMethod]
        public void QuandoTransferir50_DeveTransferirSaldo()
        {
            //ARRANGE
            var conta1 = new ContaCorrente(ClienteDeTeste, 1, 1);
            var conta2 = new ContaCorrente(ClienteDeTeste, 2, 1);
            conta1.Depositar(50);

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

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Conta Bloqueada")]
        public void ContaCorrente_QuandoTransfereParaContaBloqueada()
        {
            //ARRANGE
            var conta1 = new ContaCorrente(ClienteDeTeste, 1, 1);
            var conta2 = new ContaPoupanca(ClienteDeTeste, 2, 1);
            conta1.Depositar(100);
            conta1.Bloqueada = true;

            //ACT
            conta1.Transferir(conta2, 50);
        }


        [TestMethod]
        public void ContaCorrente_QuandoTransfereParaContaPoupancaBloqueada()
        {
            //ARRANGE
            var conta1 = new ContaCorrente(ClienteDeTeste, 1, 1);
            var conta2 = new ContaPoupanca(ClienteDeTeste, 2, 1);
            
            conta1.Depositar(100);
            conta2.Bloqueada = true;

            //ACT
            try
            {
                conta1.Transferir(conta2, 50);
            }
            catch(InvalidOperationException e)
            {
                Assert.AreEqual("Conta Destino Bloqueada", e.Message);
            }

            Assert.AreEqual(100, conta1.Saldo);
            Assert.AreEqual(0, conta2.Saldo);
            
        }



    }
}
