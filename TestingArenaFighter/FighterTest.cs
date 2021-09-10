using System;
using Xunit;
using ArenaFighter;

namespace TestingArenaFighter
{
    public class FighterTest
    {
        [Theory]
        [InlineData(5, 10, 15)]
        [InlineData(6, 10, 16)]
        [InlineData(null, 10, 10)]

        public void TestAddTwoNumbers(int? adder1,int? adder2,double expected)
        {
            //Arrange
            var sut = new Calculator();
            //Act
            var result = sut.Add(adder1, adder2);
            //Assert
            Assert.Equal(expected, result);
        }

    }

    public class Calculator
    {
        public double? Add(int? adder1, int? adder2)
        {
            var sum = (adder1 ?? 0) + (adder2 ?? 0);
            return sum;
        }
    }
}
