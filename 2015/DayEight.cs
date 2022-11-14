﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015
{
    public class DayEight : ISolveable
    {
        private string[] strs;

        public DayEight(string[] input) => strs = input;

        public int SolvePart1()
        {
            //return strs.Sum(s => s.Length);
            return strs.Sum(s => s.Length) - strs.Sum(s => CountOutput(s));
        }

        private int CountOutput(string s)
        {
            var ret = 0;

            for(var sIdx = 1; sIdx < s.Length-1; sIdx++)
            {
                if (s[sIdx] == '\\' && (s[sIdx + 1] == '"' || s[sIdx + 1] == '\\')) sIdx++;
                else if (s[sIdx] == '\\' && s[sIdx + 1] == 'x') sIdx += 3;
                ret++;
            }
            // Outside quotes
            return ret;
        }

        private int SuperCountOutput(string s)
        {
            var ret = 0;

            for (var sIdx = 0; sIdx < s.Length; sIdx++)
            {
                if (s[sIdx] == '\\') ret++;
                else if (s[sIdx] == '"') ret++;
                ret++;
            }
            // Outside quotes
            return ret + 2;
        }

        public int SolvePart2()
        {
            return strs.Sum(s => SuperCountOutput(s)) - strs.Sum(s => s.Length);
        }
    }
}
