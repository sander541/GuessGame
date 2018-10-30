using Xunit;
using GuessingApp;
using System;
using System.IO;

namespace GuessingTests
{
    public class GuessingTests
    {
        [Fact]
        public void RandomNumberIsIntegerTest()
        {
            Assert.IsType<int>(Game.GenerateRandomNumber());
        }

        [Fact]
        public void RandomNumberIsValid()
        {
            int rndNumber = Game.GenerateRandomNumber();

            Assert.InRange(Game.GenerateRandomNumber(), 1, 300);
            Assert.Equal(rndNumber, Game.IsNumberCorrect(rndNumber));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(300)]
        public void ValidUserInputReturnsNumberTest(int value)
        {
            string userInput = value.ToString();
            var sr = new StringReader(userInput);
            Console.SetIn(sr);

            int parsed = Game.GetUserNumber();
            Assert.InRange(parsed, 1, 300);
            Assert.Equal(value, parsed);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(300)]
        public void NumberCheckingWorksForValidTest(int value)
        {
            Assert.Equal(value, Game.IsNumberCorrect(value));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(3000)]
        public void InvalidInputFixedByUserTest(int value)
        {
            var sr = new StringReader("250");
            Console.SetIn(sr);

            Assert.NotEqual(value, Game.IsNumberCorrect(value));
        }
    }
}