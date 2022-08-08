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
        private Account acc;

        [TestInitialize] // runs once before each test runs
        public void CreateDefaultAccount()
        {
            acc = new Account("J Doe");
        }

        [TestMethod]
        [DataRow(100)]
        [DataRow(.01)]
        [DataRow(1.00)]
        [DataRow(1.999)]
        [DataRow(9999.99)]
        public void Deposit_APositiveAmmount_AddToBalance(double depositAmmount)
        {
            acc.Deposit(depositAmmount);

            Assert.AreEqual(depositAmmount, acc.Balance);
        }

        [TestMethod]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance()
        {
            // AAA - Arrange Act Assert

            // Arrange - set up variables
            double depositAmmount = 100;
            double expectedReturn = 100;

            // Act - Call the method
            double returnValue = acc.Deposit(depositAmmount);

            // Assert
            Assert.AreEqual(expectedReturn, returnValue);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        public void Deposit_ZeroOrLess_ThrowsArgumentException(double invalidDepositAmount)
        {
            // Arrange
            // Nothing to add here

            // Assert => Act
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => acc.Deposit(invalidDepositAmount));
        }

        [TestMethod]
        public void Withdraw_APositiveAmount_DecreasesBalance()
        {
            // Withdrawing a positive amount - returns updated balance
            // Arrange
            double initialDeposit = 100;
            double withdrawAmount = 50;
            double expectedBalance = initialDeposit - withdrawAmount;

            // Act
            acc.Deposit(initialDeposit);
            acc.Withdraw(withdrawAmount);

            double actualBalance = acc.Balance;

            // Assert
            Assert.AreEqual(expectedBalance, actualBalance);
        }

        [TestMethod]
        public void Withdraw_APositiveAmount_ReturnsUpdatedBalance()
        {
            // Withdrawing a positive amount - returns updated balance
            Assert.Fail();
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-.01)]
        [DataRow(-1000)]
        public void Withdraw_ZeroOrLess_ThrowsArgumentOutOfRangeException()
        {
            // Withdrawing 0 - Throws ArgumentOutOfRange exception
            // Withdrawing negative amount - Throws ArgumentOutOfRange eception
            Assert.Fail();
        }

        [TestMethod]
        public void Withdraw_MoreThanAvailableBalance_ThrowsArgumentException()
        {
            // Withdrawing more than balance - ArgumentException
            Assert.Fail();
        }

        
        
        
        


    }
}