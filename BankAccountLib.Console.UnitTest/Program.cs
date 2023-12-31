﻿namespace BankAccountLib.Console.UnitTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Credit_ValidAmount_IncrementBalance();

            System.Console.Read();
        }

        public static void Credit_ValidAmount_IncrementBalance()
        {
            // Arrange
            var sut = new BankAccount("Adam", 1000);
           

            // Act
            sut.Credit(100);

            var expected = 1100;

            // Assert
            if (expected == sut.Balance)
                System.Console.WriteLine(nameof(Credit_ValidAmount_IncrementBalance) + " : Passed");
            else
                System.Console.WriteLine(nameof(Credit_ValidAmount_IncrementBalance) + " : Failed");
        }
    }
}