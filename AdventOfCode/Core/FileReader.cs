namespace AdventOfCode.Core
{
    public class AdventFileReader
    {
        public const string DEFAULT_DIR = @"C:\Git\AdventOfCode\Input\2024";

        public static T GetInput<T>(string dir, string day, Func<string[], T> transform)
        {
            var lines = GetInput(dir + @"\" + day);
            return transform(lines);
        }

        public static string[] GetInput(string dir, string day)
        {
            return GetInput(dir + @"\" + day);
        }

        public static string[] GetInput(string fname)
        {
            return File.ReadAllLines(fname);
        }
    }
}