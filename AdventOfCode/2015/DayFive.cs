using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Core;

namespace AdventOfCode._2015
{
    public class DayFive : ISolveable
    {
        private string[] _possibleNiceStrings;

        public DayFive(string[] niceStringCandidates)
        {
            _possibleNiceStrings = niceStringCandidates;
        }

        public long SolvePart1()
        {
            return _possibleNiceStrings.Count(s => PassesTripleTests(s));
        }

        public long SolvePart2()
        {
            return _possibleNiceStrings.Count(s => PassesDoubleTests(s));
        }

        private bool PassesTripleTests(string s)
        {
            return HasThreeVowels(s) &&
                HasDoubleLetter(s) &&
                HasNoneOf(s, new string[] { "ab", "cd", "pq", "xy" });
        }

        private bool PassesDoubleTests(string s)
        {
            return HasDouble2Grams(s) &&
                Has3SplitPair(s);
        }

        private bool Has3SplitPair(string s)
        {
            for (var sIdx = 0; sIdx < s.Length - 2; sIdx++)
            {
                if (s[sIdx] == s[sIdx + 2]) return true;
            }
            return false;
        }

        private bool HasDouble2Grams(string s)
        {
            for (var sIdx = 0; sIdx < s.Length - 1; sIdx++)
            {
                var digram = s.Substring(sIdx, 2);
                if (s.Length - sIdx >= 2 &&
                    s.Substring(sIdx + 2, s.Length - sIdx - 2).Contains(digram))
                    return true;
            }
            return false;
        }

        private bool HasNoneOf(string s, string[] evil)
        {
            foreach (var e in evil)
            {
                if (s.Contains(e)) return false;
            }
            return true;
        }

        private bool HasDoubleLetter(string s)
        {
            var lastLetter = s[0];
            for (var cIdx = 1; cIdx < s.Length; cIdx++)
            {
                if (lastLetter == s[cIdx]) return true;
                lastLetter = s[cIdx];
            }
            return false;
        }

        private bool HasThreeVowels(string s)
        {
            return s.Count(c =>
                c == 'a' ||
                c == 'e' ||
                c == 'i' ||
                c == 'o' ||
                c == 'u') >= 3;
        }

        public string SolvePart1_Str()
        {
            throw new NotImplementedException();
        }

        public string SolvePart2_Str()
        {
            throw new NotImplementedException();
        }
    }
}
