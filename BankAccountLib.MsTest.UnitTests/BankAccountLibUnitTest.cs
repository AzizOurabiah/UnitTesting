namespace BankAccountLib.MsTest.UnitTests
{
    [TestClass]
    public class BankAccountLibUnitTest
    {
        [TestMethod]
        [TestCategory("Credit")]
        public void Credit_ValidAmount_IncrementBalance()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount("Adam", 1000);

            //Act
            bankAccount.Credit(100);
            var real = bankAccount.Balance;
            var expected = 1100;

            //Assert
            Assert.AreEqual(expected, real);
        }
        [TestMethod]
        [TestCategory("Debit")]
        public void Debit_ValidAmount_DecrementBalance()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount("Adam", 1000);

            //Act
            bankAccount.Debit(100);
            var real = bankAccount.Balance;
            var expected = 900;

            //Assert
            Assert.AreEqual(expected, real);
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
        public void Debit_AmountBiggerThenBalance_ThrowException2()
        {
            //Arrange
            var sut = new BankAccount("Adam", 1000);

            //Act
            //Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sut.Debit(2000));
        }
        [TestMethod]
        [TestCategory("Credit")]
        public void Credit_MaxAmount_ThrowException2()
        {
            //Arrange
            var sut = new BankAccount("Adam", 1000);

            //Act
            //Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sut.Credit(int.MaxValue));
        }
    }
}