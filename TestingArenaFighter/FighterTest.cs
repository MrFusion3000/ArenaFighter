using System;
using System.IO;
using Xunit;
using ArenaFighter;

namespace TestingArenaFighter
{
    public class FighterTest
    {
        [Theory]
        [InlineData("Sven", "Sven" )]
        [InlineData("Colt","Colt")]
        //[InlineData(null, 10, 10)]

        public void TestAddFighterFirstName(string firstName, string expected)
        {
            //Arrange
            Fighter fighter = new Fighter
            {
                FirstName = firstName
            };

            //Act
            var actualObj = Fighter.CreatePlayer(fighter);
            var actual = actualObj.FirstName;
            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
