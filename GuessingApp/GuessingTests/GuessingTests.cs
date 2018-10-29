using Xunit;
using GuessingApp;


namespace GuessingTests
{
    public class GuessingTests
    {
        [Fact]
        public void RandomGivesCorrectNumberTest()
        {
            Assert.InRange(Game.GenerateRandomNumber(), 1, 300);
        }
        [Fact]
        public void RandomNumberIsIntegerTest()
        {
            Assert.IsType<int>(Game.GenerateRandomNumber());
        }

        [Theory]
        [InlineData(300)]
        public void NumberControlReturnsNumberIfCorrectTest(int value)
        {
            Assert.Equal(value, Game.IsNumberCorrect(300));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(300)]
        public void ValidNumberRangeTest(int value)
        {
            Assert.True(Game.IsValidRangeNumber(value));
        }

        [Theory]
        [InlineData(500)]
        [InlineData(0)]
        [InlineData(-9)]
        public void IncorrectNumberRangeTest(int value)
        {
            Assert.False(Game.IsValidRangeNumber(value));
        }
    }
}