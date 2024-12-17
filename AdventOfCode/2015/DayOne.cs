using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Core;

namespace AdventOfCode._2015
{
    public class DayOne : ISolveable
    {
        private string _input;

        public DayOne(string input)
        {
            _input = input;
        }

        public long SolvePart1()
        {
            var ret = 0;
            for (var pIdx = 0; pIdx < _input.Length; pIdx++)
            {
                switch (_input[pIdx])
                {
                    case '(': ret++; break;
                    case ')': ret--; break;
                }
            }
            return ret;
        }

        public string SolvePart1_Str()
        {
            throw new NotImplementedException();
        }

        public long SolvePart2()
        {
            var ret = 0;
            for (var pIdx = 0; pIdx < _input.Length; pIdx++)
            {
                switch (_input[pIdx])
                {
                    case '(': ret++; break;
                    case ')': ret--; break;
                }

                if (ret < 0) return pIdx;
            }
            return -1;
        }

        public string SolvePart2_Str()
        {
            throw new NotImplementedException();
        }
    }
}
