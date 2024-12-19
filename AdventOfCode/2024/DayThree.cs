using System.Text.RegularExpressions;
using AdventOfCode.Core;

namespace AdventOfCode._2024
{
    public class DayThree : ISolveable
    {
        internal string[] _input;
        internal string regexMatcher = @"mul\([0-9]{1,3},[0-9]{1,3}\)";
        internal string exRegMatcher = @"(mul\([0-9]{1,3},[0-9]{1,3}\))|(do\(\))|(don't\(\))";

        public DayThree(int mode)
        {
            if(mode==0){
                _input = AdventFileReader.GetInput(AdventFileReader.DEFAULT_DIR, "Day3_0");
            }
            else if(mode==2){
                _input = AdventFileReader.GetInput(AdventFileReader.DEFAULT_DIR, "Day3_0_1");
            }
            else {
                _input = AdventFileReader.GetInput(AdventFileReader.DEFAULT_DIR, "Day3_1");
            }
        }

        public long SolvePart1()
        {
            var regex = new Regex(regexMatcher);
            var allMatches = new List<string>();
            foreach(var line in _input) {
                allMatches.AddRange(regex.Matches(line).Select(m => m.Value));
            }

            var sum = 0l;
            foreach(var line in allMatches){
                sum += Solve(line);
            }

            return sum;
        }

        private long Solve(string line)
        {
            var nums = line.Split(
                new List<string>(){"mul(",",",")"}.ToArray(), 
                StringSplitOptions.RemoveEmptyEntries);
            return int.Parse(nums[0]) * int.Parse(nums[1]);
        }

        public string SolvePart1_Str()
        {
            throw new NotImplementedException();
        }

        public long SolvePart2()
        {
            var regex = new Regex(exRegMatcher);
            var allMatches = new List<string>();
            foreach(var line in _input) {
                allMatches.AddRange(regex.Matches(line).Select(m => m.Value));
            }

            var sum = 0l;
            var countNext = true;
            foreach(var line in allMatches){
                switch(line){
                    case "do()": countNext = true; break;
                    case "don't()": countNext = false; break;
                    default:
                        if(countNext){
                            sum += Solve(line);
                        }
                        break;
                }
            }

            return sum;
        }

        public string SolvePart2_Str()
        {
            throw new NotImplementedException();
        }
    }
}