using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Core;

namespace AdventOfCode._2015
{
    public class DayThree : ISolveable
    {
        private Directions _dirs;
        public DayThree(string map)
        {
            _dirs = new Directions(map);
        }

        public long SolvePart1()
        {
            _dirs.Navigate();
            return _dirs.UniqueHouses;
        }

        public string SolvePart1_Str()
        {
            throw new NotImplementedException();
        }

        public long SolvePart2()
        {
            _dirs.SplitNavigate();
            return _dirs.UniqueHouses;
        }

        public string SolvePart2_Str()
        {
            throw new NotImplementedException();
        }

        private class Directions
        {
            private List<House> _houses;
            private Dictionary<int, Dictionary<int, House>> _grid;

            private string _path;

            public int UniqueHouses { get => _houses.Count(); }
            public Directions(string input)
            {
                _path = input;
                _houses = new List<House>();
                _grid = new Dictionary<int, Dictionary<int, House>>();
            }

            public void Navigate()
            {
                var currentHouse = Init();
                for (var idx = 0; idx < _path.Length; idx++)
                {
                    currentHouse = DecideMove(currentHouse, _path[idx]);
                }
            }
            public void SplitNavigate()
            {
                var currentHouse = Init();
                var roboHouse = currentHouse;

                System.Diagnostics.Debugger.Launch();

                for (var idx = 0; idx < _path.Length; idx += 2)
                {
                    currentHouse = DecideMove(currentHouse, _path[idx]);
                    if (idx + 1 < _path.Length) roboHouse = DecideMove(roboHouse, _path[idx + 1]);
                }
            }

            private House DecideMove(House currentHouse, char dir)
            {
                switch (dir)
                {
                    //East
                    case '>': return Move(0, 1, currentHouse);
                    //West
                    case '<': return Move(0, -1, currentHouse);
                    //North
                    case '^': return Move(-1, 0, currentHouse);
                    //South
                    case 'v': return Move(1, 0, currentHouse);
                    default: return null;
                }
            }

            private House Move(int yMod, int xMod, House currentHouse)
            {
                var newY = currentHouse.Y + yMod;
                var newX = currentHouse.X + xMod;

                //House does not exist
                if (!_grid.ContainsKey(newY)) _grid.Add(newY, new Dictionary<int, House>());
                if (!_grid[newY].ContainsKey(newX))
                {
                    var newHouse = new House { X = newX, Y = newY };
                    _houses.Add(newHouse);
                    _grid[newY].Add(newX, newHouse);
                }

                return _grid[newY][newX];
            }

            private House Init()
            {
                var ret = new House { X = 0, Y = 0 };
                var street1 = new Dictionary<int, House>();
                street1.Add(0, ret);
                _grid.Add(0, street1);

                _houses.Add(ret);

                return ret;
            }
        }

        private class House
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }


}
