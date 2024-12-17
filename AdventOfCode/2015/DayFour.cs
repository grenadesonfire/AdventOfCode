using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Core;

namespace AdventOfCode._2015
{
    public class DayFour : ISolveable
    {
        private string _key;

        public DayFour(string input)
        {
            _key = input;
        }

        public long SolvePart1()
        {
            var md5 = MD5.Create();

            for (var attempt = 0; attempt < 1000 * 1000 * 1; attempt++)
            {
                var bytes = System.Text.Encoding.ASCII.GetBytes(_key + $"{attempt}");
                var hashed = md5.ComputeHash(bytes);
                var output = Convert.ToHexString(hashed);

                if (output.StartsWith("00000")) return attempt;
            }

            return -1;
        }

        public string SolvePart1_Str()
        {
            throw new NotImplementedException();
        }

        public long SolvePart2()
        {
            var md5 = MD5.Create();

            for (var attempt = 0; attempt < 1000 * 1000 * 1000; attempt++)
            {
                var bytes = System.Text.Encoding.ASCII.GetBytes(_key + $"{attempt}");
                var hashed = md5.ComputeHash(bytes);
                var output = Convert.ToHexString(hashed);

                if (output.StartsWith("000000")) return attempt;
            }

            return -1;
        }

        public string SolvePart2_Str()
        {
            throw new NotImplementedException();
        }
    }
}
