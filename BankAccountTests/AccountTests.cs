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
        [TestCategory("Deposit")]
        public void Deposit_APositiveAmmount_AddToBalance(double depositAmmount)
        {
            acc.Deposit(depositAmmount);

            Assert.AreEqual(depositAmmount, acc.Balance);
        }

        [TestMethod]
        [TestCategory("Deposit")]
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
        [TestCategory("Deposit")]
        public void Deposit_ZeroOrLess_ThrowsArgumentException(double invalidDepositAmount)
        {
            // Arrange
            // Nothing to add here

            // Assert => Act
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => acc.Deposit(invalidDepositAmount));
        }

        [TestMethod]
        [TestCategory("Withdraw")]
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
        [DataRow(100, 50)]
        [TestCategory("Withdraw")]
        public void Withdraw_APositiveAmount_ReturnsUpdatedBalance(double initialDeposit, double withdrawAmount)
        {
            // Withdrawing a positive amount - returns updated balance
            // Arrange
            initialDeposit = 100;
            withdrawAmount = 50;
            double expectedBalance = initialDeposit - withdrawAmount;
            acc.Deposit(initialDeposit);
            // Act
            double returnBalance = acc.Withdraw(withdrawAmount);
            // Assert
            Assert.AreEqual(expectedBalance, returnBalance);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-.01)]
        [DataRow(-1000)]
        [TestCategory("Withdraw")]
        public void Withdraw_ZeroOrLess_ThrowsArgumentOutOfRangeException(double withdrawAmount)
        {
            // Withdrawing 0 - Throws ArgumentOutOfRange exception
            // Withdrawing negative amount - Throws ArgumentOutOfRange eception
            

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => acc.Withdraw(withdrawAmount));
        }

        [TestCategory("Withdraw")]
        [TestMethod]
        public void Withdraw_MoreThanAvailableBalance_ThrowsArgumentException()
        {
            // Withdrawing more than balance - ArgumentException
            double withdrawAmount = 1000;

            Assert.ThrowsException<ArgumentException>(() => acc.Withdraw(withdrawAmount));
        }

        [TestMethod]
        public void Owner_SetAsNull_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => acc.Owner = null);
        }

        [TestMethod]
        public void Owner_SetAsWhiteSpaceOrEmptyString_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = String.Empty);
        }

        [TestMethod]
        [DataRow("Jordan")]
        [DataRow("Jordan Rabold")]
        [DataRow("Jordan Reid Rabolddddd")]
        public void Owner_SetAsUpTo20Characters_SetsSuccessfully(string ownerName)
        {
            // Set
            acc.Owner = ownerName;
            Assert.AreEqual(ownerName, acc.Owner);
        }

        [TestMethod]
        [DataRow("Jordan 3rd")]
        [DataRow("Jordan Reid Rabolddddds")]
        [DataRow("#$%#$")]
        public void Owner_InvalidOwnerName_ThrowsArgumentException(string ownerName)
        {
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = ownerName);
        }
        
        
        
        


    }
}