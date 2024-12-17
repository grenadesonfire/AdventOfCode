namespace AdventOfCode.Tests
{
    public class Tests_2024
    {
        [Fact]
        public void DayOneGiven_Part1()
        {
            var day = new _2024.DayOne(0);

            Assert.Equal(11, day.SolvePart1());
        }

        [Fact]
        public void DayOneInput_Part1()
        {
            var day = new _2024.DayOne(1);

            Assert.Equal(1938424, day.SolvePart1());
        }

        [Fact]
        public void DayOneGiven_Part2()
        {
            var day = new _2024.DayOne(0);

            Assert.Equal(31, day.SolvePart2());
        }

        [Fact]
        public void DayOneInput_Part2()
        {
            var day = new _2024.DayOne(1);

            Assert.Equal(0, day.SolvePart2());
        }
    }
}