using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015
{
    /// <summary>
    /// There are two initial ways I thought to solve this:
    ///     1) The naive way, just make an array of 1,000,000 and flip on or off
    ///     2) Make an https://en.wikipedia.org/wiki/Interval_tree
    /// </summary>
    public class DaySix : ISolveable
    {
        private List<LightCommand> _commands;

        public DaySix(string[] commands)
        {
            _commands = commands.Select(c => new LightCommand(c)).ToList(); ;
        }

        public int SolvePart1()
        {
            var grid = new LightGrid(_commands);
            grid.RunCommands();
            return grid.On;
        }

        public int SolvePart2()
        {
            var grid = new LightGridV2(_commands);
            grid.RunCommands();
            return grid.Brightness;
        }

        private class LightGridV2 
        {
            private List<LightCommand> _commands;
            private int[,] _grid;
            public int Brightness { get; set; } = 0;

            public LightGridV2(List<LightCommand> commands)
            {
                _commands = commands;
                _grid = new int[1000, 1000];
            }

            public void RunCommands()
            {
                foreach (var cmd in _commands)
                {
                    Execute(cmd);
                }
            }

            private void Execute(LightCommand cmd)
            {
                for (var yIdx = cmd.Top.Y; yIdx <= cmd.Bottom.Y; yIdx++)
                {
                    for (var xIdx = cmd.Top.X; xIdx <= cmd.Bottom.X; xIdx++)
                    {
                        switch (cmd.Instruction)
                        {
                            case LightCommandInst.OFF:
                                if (_grid[yIdx, xIdx] > 0) Brightness--;
                                _grid[yIdx, xIdx] = Math.Max(0, _grid[yIdx, xIdx]-1);
                                break;
                            case LightCommandInst.ON:
                                Brightness += 1;
                                _grid[yIdx, xIdx]++;
                                break;
                            case LightCommandInst.TOGGLE:
                                _grid[yIdx, xIdx]+=2;
                                Brightness += 2;
                                break;
                        }
                    }
                }
            }
        }

        private class LightGrid
        {
            private List<LightCommand> _commands;
            private bool[,] _grid;
            public int On { get; set; } = 0;

            public LightGrid(List<LightCommand> commands)
            {
                _commands = commands;
                _grid = new bool[1000, 1000];
            }

            public void RunCommands()
            {
                foreach(var cmd in _commands)
                {
                    Execute(cmd);
                }
            }

            private void Execute(LightCommand cmd)
            {
                for(var yIdx = cmd.Top.Y; yIdx <= cmd.Bottom.Y; yIdx++)
                {
                    for(var xIdx = cmd.Top.X;xIdx<=cmd.Bottom.X;xIdx++)
                    {
                        switch (cmd.Instruction)
                        {
                            case LightCommandInst.OFF:
                                if (_grid[yIdx, xIdx]) On--;
                                _grid[yIdx, xIdx] = false;
                                break;
                            case LightCommandInst.ON:
                                if (!_grid[yIdx, xIdx]) On++;
                                _grid[yIdx, xIdx] = true;
                                break;
                            case LightCommandInst.TOGGLE:
                                _grid[yIdx, xIdx] = !_grid[yIdx, xIdx];
                                On += _grid[yIdx, xIdx] ? 1 : -1;
                                break;
                        }
                    }
                }
            }
        }
        private enum LightCommandInst
        {
            ON,
            OFF,
            TOGGLE
        }

        private class LightCommand
        {
            public LightCommandInst Instruction { get; set; }
            public Point Top { get; set; }
            public Point Bottom { get; set; }

            public LightCommand(string c)
            {
                var parts = c.Split(' ');

                if (parts.Length == 5)
                {
                    Instruction = parts[1] == "on" ? LightCommandInst.ON : LightCommandInst.OFF;
                    Top = StrToPoint(parts[2]);
                    Bottom = StrToPoint(parts[4]);
                }
                else
                {
                    Instruction = LightCommandInst.TOGGLE;
                    Top = StrToPoint(parts[1]);
                    Bottom = StrToPoint(parts[3]);
                }
            }

            private Point StrToPoint(string v)
            {
                var nums = v.Split(',');
                return new Point(int.Parse(nums[0]), int.Parse(nums[1]));
            }
        }
    }
}
