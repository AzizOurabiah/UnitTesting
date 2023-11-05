namespace BankAccountLib.MsTest.UnitTests
{
    [TestClass]
    public class BankAccountLibUnitTest
    {
        [TestMethod]
        [TestCategory("Credit")]
        [DataRow(1000, 100, 1100, 1100)]
        [DataRow(2000, 100, 2100, 2100)]
        [DataRow(3000, 100, 3100, 3100)]
        public void Credit_ValidAmount_IncrementBalance(double amount, double credit, double expected, double actual)
        {
            //Arrange
            BankAccount bankAccount = new BankAccount("Adam", amount);

            //Act
            bankAccount.Credit(credit);
            //var real = bankAccount.Balance;
            //var expected = 1100;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [TestCategory("Debit")]
        [DataRow(1000, 100, 900, 900)]
        [DataRow(2000, 100, 1900, 1900)]
        [DataRow(3000, 100, 2900, 2900)]
        public void Debit_ValidAmount_DecrementBalance(double amount, double debit, double expected, double actual)
        {
            //Arrange
            BankAccount bankAccount = new BankAccount("Adam", amount);

            //Act
            bankAccount.Debit(debit);
            //var real = bankAccount.Balance;
            //var expected = 900;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [TestCategory("Debit")]
        [Ignore("Bad Test case catch Exception inside the test methode")]
        public void Debit_AmountBiggerThenBalance_ThrowException()
        {
            //Arrange
            var sut = new BankAccount("Adam", 1000);

            //Act
            try
            {
                sut.Debit(2000);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                //var actual = sut.Balance;
                //double expected = 0;

                //Assert
                //Assert.AreEqual(expected, actual);
                Assert.AreEqual("amount",ex.ParamName);
            } 
        }
        [TestMethod]
        [TestCategory("Debit")]
        [DataRow(1000, 2000)]
        [DataRow(1000, 3000)]
        [DataRow(1000, 4000)]
        public void Debit_AmountBiggerThenBalance_ThrowException2(double amount, double debit)
        {
            //Arrange
            var sut = new BankAccount("Adam", amount);

            //Act
            //Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sut.Debit(debit));
        }
        [TestMethod]
        [TestCategory("Credit")]
        [DataRow(1000)]
        [DataRow(2000)]
        [DataRow(3000)]
        public void Credit_MaxAmount_ThrowException2(double amount)
        {
            //Arrange
            var sut = new BankAccount("Adam", amount);

            //Act
            //Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sut.Credit(int.MaxValue));
        }
    }
}