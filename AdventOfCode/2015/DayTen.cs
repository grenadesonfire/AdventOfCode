using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Core;

namespace AdventOfCode._2015
{
    public class DayTen : ISolveable
    {
        private string _start;
        private int _rounds;
        Dictionary<string, string> _cache;

        public DayTen(string start, int rounds)
        {
            _start = start;
            _rounds = rounds;
            _cache = new Dictionary<string, string>();
        }

        public long SolvePart1()
        {
            return SolvePart1_Str().Length;
        }

        public string SolvePart1_Str()
        {
            var morph = _start;
            for (var round = 0; round < _rounds; round++)
            {
                morph = Expand(morph);
            }
            return morph;
        }

        private string Expand(string morph)
        {
            if (morph.Length == 0) return "";
            if (_cache.ContainsKey(morph)) return _cache[morph];

            var sb = new StringBuilder();

            if (morph.Length == 1)
            {
                sb.Append(morph);
                sb.Append("1");
            }
            else
            {
                var current = morph[0];
                var count = 1;
                for (var cIdx = 1; cIdx < morph.Length; cIdx++)
                {
                    if (morph[cIdx] == current) count++;
                    else
                    {
                        sb.Append(count);
                        sb.Append(current);

                        count = 1;
                        current = morph[cIdx];
                    }
                }
                sb.Append(count);
                sb.Append(current);

            }

            _cache.Add(morph, sb.ToString());
            return sb.ToString();
        }

        public long SolvePart2()
        {
            throw new NotImplementedException();
        }

        public string SolvePart2_Str()
        {
            throw new NotImplementedException();
        }
    }
}
