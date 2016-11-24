using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankSystem.Core;

namespace BankSystem.Tests
{
    [TestClass]
    public class ContaBancariaTest
    {
        [TestMethod]
        public void ContaBancaria_QuandoDepositar50_IncrementarSaldo()
        {
            //Arrange
            var cliente = new Cliente() { TipoDoc = Cliente.TipoDocumento.CPF, NumeroDoc = "111.233.333-12", Nome = "TESTE" };
            var conta = new ContaBancaria(cliente, 1, 1001);

            //Act
            conta.Creditar(50, "DEPOSITO DINHEIRO");

            //Assert
            Assert.AreEqual(50, conta.Saldo);
        }
    }
}
