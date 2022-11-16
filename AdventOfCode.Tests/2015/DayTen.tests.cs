using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests._2015
{
    public class DayTen
    {
        [Fact]
        public void PassesGivenTestCase()
        {
            var input = "1";
            var rounds = 5;

            var d10 = new AdventOfCode._2015.DayTen(input, rounds);

            var ans = d10.SolvePart1_Str();

            Assert.Equal("312211", ans);
        }
    }
}
