using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Core;

namespace AdventOfCode._2015
{
    public class DayTwo : ISolveable
    {
        private List<Present> _presents;
        public DayTwo(string[] inputs)
        {
            _presents = new List<Present>();
            _presents.AddRange(inputs.Select(inp => new Present(inp)));
        }

        public long SolvePart1()
        {
            return _presents.Sum(p => p.PaperNeeded());
        }

        public string SolvePart1_Str()
        {
            throw new NotImplementedException();
        }

        public long SolvePart2()
        {
            return _presents.Sum(p => p.RibbonNeeded());
        }

        public string SolvePart2_Str()
        {
            throw new NotImplementedException();
        }

        private class Present
        {
            private int[] _dimensions;

            public Present(string input)
            {
                _dimensions = input.Split('x').Select(i => int.Parse(i)).ToArray();
            }

            public int PaperNeeded()
            {
                var sides = new List<int>
                {
                    _dimensions[0] * _dimensions[1],
                    _dimensions[0] * _dimensions[2],
                    _dimensions[2] * _dimensions[1],
                };

                return sides.Sum() * 2 + sides.Min();
            }

            internal int RibbonNeeded()
            {
                //you need 2* the smallest two sides so just add them all and subtract the biggest
                return (_dimensions.Sum() - _dimensions.Max()) * 2 + Volume();
            }

            private int Volume()
            {
                return _dimensions[0] *
                    _dimensions[1] *
                    _dimensions[2];
            }
        }
    }
}
