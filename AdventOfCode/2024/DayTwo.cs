using AdventOfCode.Core;

namespace AdventOfCode._2024
{
    public class Report
    {
        public List<int> Items { get; set; } = new List<int>();

        internal bool IsSafe(int min, int max)
        {
            return IsSafe(Items.ToArray(), min, max);
        }

        internal bool IsSafe(int[] reportItems,int min, int max)
        {
            // Technically I could use one but also this is more obvious
            var isIncreasing = reportItems[0] < reportItems[1];
            var isDecreasing = reportItems[0] > reportItems[1];
            var diff = Math.Abs(reportItems[0]-reportItems[1]);
            if(diff < min || diff > max) return false;

            if(!isIncreasing && !isDecreasing) return false;

            for(int idx=1;idx<reportItems.Length-1;idx++) {
                if(isIncreasing && reportItems[idx] > reportItems[idx+1]) return false;
                if(isDecreasing && reportItems[idx] < reportItems[idx+1]) return false;

                diff = Math.Abs(reportItems[idx]-reportItems[idx+1]);
                if(diff < min || diff > max) return false;
            }

            return true;
        }

        /// <summary>
        /// Part Two function
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        internal bool IsReallySafe(int min, int max)
        {
            if(IsSafe(Items.ToArray(), min, max)) return true;

            var maxItems = Items.Count();

            for(var idx=0;idx<maxItems;idx++){
                var testArr = new List<int>();
                
                if(idx == 0 && IsSafe(Items.Skip(1).ToArray(), min, max)) 
                    return true;
                else {
                    var subItems = Items.Take(idx).ToList();
                    subItems.AddRange(Items.Skip(idx+1).ToList());

                    if(IsSafe(subItems.ToArray(), min, max)) return true;
                }
            }

            return false;
        }
    }

    public class DayTwo : ISolveable
    {
        public List<Report> Reports { get; set; }

        public DayTwo(int mode)
        {
            if (mode == 0)
            {
                Reports = AdventFileReader.GetInput(
                    @"C:\Git\AdventOfCode\Input\2024",
                    "Day2_0",
                    ConvertReports);
            }
            else
            {
                Reports = AdventFileReader.GetInput(
                    @"C:\Git\AdventOfCode\Input\2024",
                    "Day2_1",
                    ConvertReports);
            }
        }

        List<Report> ConvertReports(string[] lines)
        {
            var reports = new List<Report>();

            foreach (var line in lines)
            {
                var report = new Report();
                report.Items =
                    line
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(s => int.Parse(s))
                        .ToList();
                
                reports.Add(report);
            }

            return reports;
        }

        public long SolvePart1()
        {
            var sum = 0;

            foreach(var report in Reports)
            {
                if(report.IsSafe(1,3)) sum++;
            }

            return sum;
        }

        public string SolvePart1_Str()
        {
            return string.Join("\n", Reports.Where(r => r.IsSafe(1,3)).Select(r => string.Join(" ", r.Items)));
        }

        public long SolvePart2()
        {
            var sum = 0;

            foreach(var report in Reports)
            {
                if(report.IsReallySafe(1,3)) sum++;
            }

            return sum;
        }

        public string SolvePart2_Str()
        {
            throw new NotImplementedException();
        }
    }
}