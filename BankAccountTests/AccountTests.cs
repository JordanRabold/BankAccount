using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        [TestMethod]
        public void Deposit_APositiveAmmount_AddToBalance()
        {
            Account acc = new("J Dog");
            acc.Deposit(100);

            Assert.AreEqual(100, acc.Balance);
        }

        [TestMethod]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance()
        {
            // AAA - Arrange Act Assert

            // Arrange - set up variables
            Account acc = new("J. Doe");
            double depositAmmount = 100;
            double expectedReturn = 100;

            // Act - Call the method
            double returnValue = acc.Deposit(depositAmmount);

            // Assert
            Assert.AreEqual(expectedReturn, returnValue);
        }
    }
}