using AdventOfCode.Core;

namespace AdventOfCode._2024
{
    public class DayOne : ISolveable
    {
        private List<int> _list1 = new List<int>();
        private List<int> _list2 = new List<int>();

        public DayOne(int mode)
        {
            string[] lines;

            if (mode == 0) lines = File.ReadAllLines(@"C:\Git\AdventOfCode\Input\2024\Day1_0");
            else lines = File.ReadAllLines(@"C:\Git\AdventOfCode\Input\2024\Day1_1");

            foreach (var line in lines)
            {
                var split = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                _list1.Add(int.Parse(split[0]));
                _list2.Add(int.Parse(split[1]));
            }
        }

        public long SolvePart1()
        {
            var sum = 0l;
            _list1.Sort();
            _list2.Sort();

            for (int idx = 0; idx < _list1.Count; idx++)
            {
                sum += Math.Abs(_list1[idx] - _list2[idx]);
            }

            return sum;
        }

        public string SolvePart1_Str()
        {
            throw new NotImplementedException();
        }

        public long SolvePart2()
        {
            var sum = 0l;

            foreach (var item in _list1)
            {
                sum += _list2.Count(_l => item == _l) * item;
            }

            return sum;
        }

        public string SolvePart2_Str()
        {
            throw new NotImplementedException();
        }
    }
}