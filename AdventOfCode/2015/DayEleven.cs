using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015
{
    public class DayEleven : ISolveable
    {
        private SantaPassword _pwd;

        public DayEleven(string pwd)
        {
            _pwd = new SantaPassword(pwd);
        }
        public int SolvePart1()
        {
            throw new NotImplementedException();
        }

        public string SolvePart1_Str()
        {
            _pwd.FindNextValid();
            return _pwd.ToString();
        }

        public int SolvePart2()
        {
            return 0;
        }

        public string SolvePart2_Str()
        {
            _pwd.Increment();
            _pwd.FindNextValid();
            return _pwd.ToString();
        }

        public string Increment()
        {
            _pwd.Increment();
            return _pwd.ToString();
        }

        public bool ValidateCurrent()
        {
            return _pwd.Validate();
        }

        private class SantaPassword
        {
            public List<int> Converted { get; set; }

            public SantaPassword(string pwd)
            {
                Converted = pwd.Select(c => c - 'a').ToList();
            }

            public override string ToString()
            {
                return string.Join("", Converted.Select(c => (char)(c + 'a')));
            }

            internal bool Validate()
            {
                return Increasing() &&
                    DoesNotContain(new char[] { 'i', 'o', 'l' }) &&
                    Contains2Doubles();
            }

            private bool Contains2Doubles()
            {
                var firstPassed = false;
                for(var idx = 0; idx < Converted.Count-1; idx++)
                {
                    if (Converted[idx] == Converted[idx + 1])
                    {
                        if (firstPassed) return true;
                        else firstPassed = true;
                        idx++;
                    }
                }
                return false;
            }

            private bool DoesNotContain(char[] strings)
            {
                foreach(var test in strings)
                {
                    if (Converted.Contains((int)(test-'a'))) return false;
                }
                return true;
            }

            private bool Increasing()
            {
                for(var idx=0;idx<Converted.Count-2;idx++)
                {
                    if (Converted[idx] + 1 == Converted[idx + 1] &&
                        Converted[idx] + 2 == Converted[idx + 2])
                        return true;
                }
                return false;
            }

            internal void FindNextValid()
            {
                while (!Validate())
                {
                    Increment();
                }
            }

            internal void Increment()
            {
                Converted[Converted.Count-1]++;
                for (var idx = Converted.Count-1; idx > 0; idx--)
                {
                    if (Converted[idx] >= 26)
                    {
                        Converted[idx - 1]++;
                        Converted[idx] = 0;
                    }
                }

                //Special case
                if (Converted[0] > 26)
                {
                    throw new Exception("Overflow and I'm too lazy to implement");
                }
            }
        }
    }
}
