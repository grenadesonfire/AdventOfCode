using System.Data.SqlTypes;
using AdventOfCode.Core;

namespace AdventOfCode._2024
{
    public enum GridDirection
    {
        TopLeft,
        Top,
        TopRight,
        Left,
        Right,
        BottomLeft,
        Bottom,
        BottomRight
    }

    public class GridPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public GridPoint(int row, int col)
        {
            Y = row;
            X = col;
        }
    }

    public class Grid<T>
    {
        internal int[] ROWMOD = { -1, -1, -1, 0, 0, 1, 1, 1 };
        internal int[] COLMOD = { -1, 0, 1, -1, 1, -1, 0, 1 };

        private List<List<T>> _innerGrid = new List<List<T>>();

        public List<GridPoint> Points()
        {
            var points = new List<GridPoint>();

            for (var row = 0; row < _innerGrid.Count; row++)
            {
                for (var col = 0; col < _innerGrid.Count; col++)
                {
                    points.Add(new GridPoint(row, col));
                }
            }

            return points;
        }

        public bool ValidPoint(GridPoint gp, GridDirection gd, int distance)
        {
            var check = new GridPoint(
                gp.Y + ROWMOD[(int)gd] * distance,
                gp.X + COLMOD[(int)gd] * distance
            );

            return check.X >= 0 &&
                check.X < _innerGrid[0].Count &&
                check.Y >= 0 &&
                check.Y < _innerGrid.Count;
        }

        public T GetItem(GridPoint gp, GridDirection gd, int distance)
        {
            var check = new GridPoint(
                gp.Y + ROWMOD[(int)gd] * distance,
                gp.X + COLMOD[(int)gd] * distance
            );

            return _innerGrid[check.Y][check.X];
        }

        public void CopyGrid(Grid<T> source)
        {
            _innerGrid = source._innerGrid;
        }

        public static Grid<T> FromFile(string[] lines, Func<char, T> itemConverter)
        {
            var grid = new Grid<T>();

            foreach (var line in lines)
            {
                var row = new List<T>();

                foreach (var c in line)
                {
                    row.Add(itemConverter(c));
                }

                grid._innerGrid.Add(row);
            }

            return grid;
        }

        public static GridDirection[] EightDirections()
        {
            return new GridDirection[]{
                GridDirection.TopLeft,
                GridDirection.Top,
                GridDirection.TopRight,
                GridDirection.Left,
                GridDirection.Right,
                GridDirection.BottomLeft,
                GridDirection.Bottom,
                GridDirection.BottomRight
            };
        }
    }

    public class CharGrid : Grid<char>
    {
        public bool WordInDirection(string word, GridPoint gp, GridDirection gd)
        {
            for (var idx = 0; idx < word.Length; idx++)
            {
                if (!ValidPoint(gp, gd, idx)) return false;

                if (word[idx] != GetItem(gp, gd, idx)) return false;
            }
            return true;
        }

        internal static char ConvertGridPoint(char item)
        {
            return item;
        }

        public static CharGrid FromFile(string[] lines)
        {
            var grid = FromFile(lines, ConvertGridPoint);
            var ret = new CharGrid();

            ret.CopyGrid(grid);
            return ret;
        }
    }

    public class DayFour : ISolveable
    {
        private CharGrid _grid;

        public DayFour(int mode)
        {
            if (mode == 0)
            {
                _grid = AdventFileReader.GetInput(
                    AdventFileReader.DEFAULT_DIR,
                    "Day4_0",
                    CharGrid.FromFile
                );
            }
            else
            {
                _grid = AdventFileReader.GetInput(
                    AdventFileReader.DEFAULT_DIR,
                    "Day4_1",
                    CharGrid.FromFile
                );
            }
        }

        public long SolvePart1()
        {
            var xmasFound = 0L;

            foreach (var p in _grid.Points())
            {
                //Check each direction, the type argument here is irrelevant
                foreach (var d in Grid<char>.EightDirections())
                {
                    if (_grid.WordInDirection("XMAS", p, d)) xmasFound++;
                }
            }

            return xmasFound;
        }

        public string SolvePart1_Str()
        {
            throw new NotImplementedException();
        }

        public long SolvePart2()
        {
            var xmasFound = 0L;

            foreach (var p in _grid.Points())
            {
                if (_grid.GetItem(p, GridDirection.TopLeft, 0) == 'A')
                {
                    if (!_grid.ValidPoint(p, GridDirection.TopLeft, 1) ||
                        !_grid.ValidPoint(p, GridDirection.TopRight, 1) ||
                        !_grid.ValidPoint(p, GridDirection.BottomLeft, 1) ||
                        !_grid.ValidPoint(p, GridDirection.BottomRight, 1)) continue;
                    var corners = "" +
                        _grid.GetItem(p, GridDirection.TopLeft, 1) +
                        _grid.GetItem(p, GridDirection.TopRight, 1) +
                        _grid.GetItem(p, GridDirection.BottomRight, 1) +
                        _grid.GetItem(p, GridDirection.BottomLeft, 1);

                    switch (corners)
                    {
                        case "MMSS":
                        case "SMMS":
                        case "SSMM":
                        case "MSSM":
                            xmasFound++;
                            break;
                    }
                }
            }

            return xmasFound;
        }

        public string SolvePart2_Str()
        {
            throw new NotImplementedException();
        }
    }
}