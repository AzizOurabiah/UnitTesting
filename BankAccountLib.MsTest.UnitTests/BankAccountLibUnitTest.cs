namespace BankAccountLib.MsTest.UnitTests
{
    [TestClass]
    public class BankAccountLibUnitTest
    {
        [TestMethod]
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
    }
}