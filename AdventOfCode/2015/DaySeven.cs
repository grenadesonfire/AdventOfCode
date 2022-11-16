using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015
{
    public class DaySeven : ISolveable
    {
        private List<Instruction> _instructions;
        
        public DaySeven(string[] lines)
        {
            _instructions = lines.Select(s => new Instruction(s)).ToList();
        }

        public int TestVM(string label)
        {
            var vm = new LogicMachine(_instructions);
            return vm.Execute(label);
        }

        public int SolvePart1()
        {
            
            var vm = new LogicMachine(_instructions);
            return vm.Execute("a");
        }

        public int SolvePart2()
        {
            var vm = new LogicMachine(_instructions);
            var rest = vm.Execute("a");

            vm.OverWriteWire("b", rest);
            vm.ClearCache();
            return vm.Execute("a");
        }

        public string SolvePart1_Str()
        {
            throw new NotImplementedException();
        }

        public string SolvePart2_Str()
        {
            throw new NotImplementedException();
        }

        private class LogicMachine
        {
            private List<Instruction> _instructions;
            private Dictionary<string, ushort> _cache = new Dictionary<string, ushort>();

            private const int UNSIGNED_SHORT_MAX = (short.MaxValue * 2 + 1);

            public LogicMachine(List<Instruction> instructions) => _instructions = instructions;

            public ushort Execute(string label)
            {
                var instr = _instructions.First(i => i.ResultLocation == label);
                ushort checkedArg1 = LiteralOrLookup(instr.Arg1);
                ushort checkedArg2 = LiteralOrLookup(instr.Arg2);

                try
                {
                    switch (instr.Type)
                    {
                        case InstructionType.Assignment:
                            return checkedArg1;
                        case InstructionType.And:
                            return (ushort)(checkedArg1 & checkedArg2);
                        case InstructionType.Or:
                            return (ushort)(checkedArg1 | checkedArg2);
                        // Perform left shift operation, handle over flow by & with max value for short - 16 bit value
                        case InstructionType.Lshift:
                            return (ushort)((checkedArg1 << int.Parse(instr.Arg2)) & UNSIGNED_SHORT_MAX);
                        case InstructionType.Rshift:
                            return (ushort)((checkedArg1 >> int.Parse(instr.Arg2)));
                        case InstructionType.Not:
                            return (ushort)(~checkedArg1 & UNSIGNED_SHORT_MAX);
                        default:
                            throw new NotImplementedException("There is nothing to handle that method.");
                    }
                }
                catch(Exception ex)
                {
                    System.Diagnostics.Debugger.Launch();
                    throw ex;
                }
            }

            private ushort LiteralOrLookup(string arg)
            {
                if (string.IsNullOrEmpty(arg)) return 0;
                if (ushort.TryParse(arg, out var literal)) return literal;
                if (_cache.ContainsKey(arg)) return _cache[arg];
                // This means do a lookup if its not a literal
                var ret = Execute(arg);
                _cache.Add(arg, ret);
                return ret;
            }

            internal void OverWriteWire(string label, ushort result)
            {
                var instr = _instructions.First(i => i.ResultLocation == label);
                instr.Type = InstructionType.Assignment;
                instr.Arg1 = $"{result}";
            }

            internal void ClearCache()
            {
                _cache.Clear();
            }
        }

        private class Connection
        {
            public string Label { get; set; }
            public Dictionary<string, Connection> Destinations { get; set; } = new Dictionary<string, Connection>();
            public Instruction Source { get; set; }
        }

        private enum InstructionType
        {
            Not,
            And,
            Or,
            Assignment,
            Lshift,
            Rshift
        }

        private class Instruction
        {
            public InstructionType Type { get; set; }
            public string ResultLocation { get; set; }
            public string Arg1 { get; set; }
            public string Arg2 { get; set; }
            public Instruction(string s)
            {
                var halves = s.Split("->");
                ResultLocation = halves[1].Trim();

                var terms = halves[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                // Assignment
                if(terms.Length == 1)
                {
                    Type = InstructionType.Assignment;
                    Arg1 = terms[0];
                }
                // Not
                else if(terms.Length == 2)
                {
                    Type = InstructionType.Not;
                    Arg1 = terms[1];
                }
                else
                {
                    switch (terms[1])
                    {
                        case "AND": Type = InstructionType.And;break;
                        case "OR": Type = InstructionType.Or; break;
                        case "LSHIFT": Type = InstructionType.Lshift; break;
                        case "RSHIFT": Type = InstructionType.Rshift; break;
                    }
                    Arg1 = terms[0];
                    Arg2 = terms[2];
                }
            }
        }
    }
}
