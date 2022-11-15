using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests._2015
{
    public class DayNine
    {
        [Fact]
        public void PassesGivenTestCase()
        {
            var input = new string[]
            {
                "London to Dublin = 464",
                "London to Belfast = 518",
                "Dublin to Belfast = 141"
            };

            var day = new AdventOfCode._2015.DayNine(input);

            Assert.Equal(605, day.SolvePart1());
        }
    }
}
