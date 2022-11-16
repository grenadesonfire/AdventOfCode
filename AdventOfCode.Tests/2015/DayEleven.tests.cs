using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests._2015
{
    public class DayEleven
    {
        [Fact]
        public void Validation_Fails_DisallowdCharacters()
        {
            var pwd = new AdventOfCode._2015.DayEleven("hijklmmn");

            Assert.False(pwd.ValidateCurrent());
        }

        [Fact]
        public void Validation_Fails_3CharacterStraight()
        {
            var pwd = new AdventOfCode._2015.DayEleven("abbceffg");

            Assert.False(pwd.ValidateCurrent());
        }

        [Fact]
        public void Validation_Fails_DoubleCharacter()
        {
            var pwd = new AdventOfCode._2015.DayEleven("abccegjk");

            Assert.False(pwd.ValidateCurrent());
        }

        [Fact]
        public void Validation_Increment()
        {
            var pwd = new AdventOfCode._2015.DayEleven("abcdefgh");

            var next = pwd.Increment();

            Assert.Equal("abcdefgi", next);
        }

        [Fact]
        public void Validation_NextPassword()
        {
            var pwd = new AdventOfCode._2015.DayEleven("abcdefgh");

            var next = pwd.SolvePart1_Str();

            Assert.Equal("abcdffaa", next);
        }
    }
}
