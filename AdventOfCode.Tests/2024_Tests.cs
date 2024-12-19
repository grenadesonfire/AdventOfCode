namespace AdventOfCode.Tests
{
    public class Tests_2024_DayOne
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

    public class Tests_2024_DayTwo
    {
        [Fact]
        public void DayTwoGiven_Part1()
        {
            var day = new _2024.DayTwo(0);

            Assert.Equal(2, day.SolvePart1());
        }

        [Fact]
        public void DayTwoInput_Part1()
        {
            var day = new _2024.DayTwo(1);

            var output = day.SolvePart1_Str();

            Assert.Equal(252, day.SolvePart1());
        }

        [Fact]
        public void DayTwoGiven_Part2()
        {
            var day = new _2024.DayTwo(0);

            Assert.Equal(4, day.SolvePart2());
        }

        [Fact]
        public void DayTwoInput_Part2()
        {
            var day = new _2024.DayTwo(1);

            Assert.Equal(324, day.SolvePart2());
        }
    }

    public class Tests_2024_DayThree
    {
        [Fact]
        public void DayThreeGiven_Part1()
        {
            var day = new _2024.DayThree(0);

            Assert.Equal(161, day.SolvePart1());
        }

        [Fact]
        public void DayThreeInput_Part1()
        {
            var day = new _2024.DayThree(1);

            Assert.Equal(175615763, day.SolvePart1());
        }

        [Fact]
        public void DayThreeGiven_Part2()
        {
            var day = new _2024.DayThree(2);

            Assert.Equal(48, day.SolvePart2());
        }

        [Fact]
        public void DayThreeInput_Part2()
        {
            var day = new _2024.DayThree(1);

            Assert.Equal(74361272, day.SolvePart2());
        }
    }

    public class Tests_2024_DayFour
    {
        [Fact]
        public void Given_Part1()
        {
            var day = new _2024.DayFour(0);

            Assert.Equal(18, day.SolvePart1());
        }

        [Fact]
        public void Input_Part1()
        {
            var day = new _2024.DayFour(1);

            Assert.Equal(2462, day.SolvePart1());
        }

        [Fact]
        public void Given_Part2()
        {
            var day = new _2024.DayFour(0);

            Assert.Equal(9, day.SolvePart2());
        }

        [Fact]
        public void Input_Part2()
        {
            var day = new _2024.DayFour(1);

            Assert.Equal(1877, day.SolvePart2());
        }
    }
}