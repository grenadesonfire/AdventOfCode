using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015
{
    public class DayNine : ISolveable
    {
        private List<Route> _routes;
        private List<string> _locations;

        public DayNine(string[] input)
        {
            _routes = input.Select(s => new Route(s)).ToList();
            _locations = _routes.Select(r => r.Location1).ToList();
            _locations.AddRange(_routes.Select(r => r.Location2));
            _locations = _locations.Distinct().ToList();
        }

        public int SolvePart1()
        {
            return StartDFS();
        }

        private int StartDFS()
        {
            var min = int.MaxValue;

            foreach(var place in _locations)
            {
                var visited = new List<string> { place };

                var minRoute = DFS(visited, place);

                if (minRoute < min) min = minRoute;
            }

            return min;
        }

        private int DFS(List<string> visited, string currentlyAt)
        {
            var left = _locations.Where(l => !visited.Contains(l));

            if (left.Count() == 0) return 0;

            var min = int.MaxValue;
            var best = string.Empty;

            foreach(var place in left)
            {
                //Create the new list so we don't mess up other branches
                // could also use a queue or stack but ehhh.
                var newVisit = visited.ToList();
                newVisit.Add(place);

                var dist = DFS(newVisit, place);

                if(dist < min)
                {
                    min = dist;
                    best = place;
                }
            }

            return min + LookupDistance(currentlyAt, best);
        }

        private int LookupDistance(string currentlyAt, string place)
        {
            return _routes
                .FirstOrDefault(s =>
                    (s.Location1 == currentlyAt || s.Location1 == place) &&
                    (s.Location2 == currentlyAt || s.Location2 == place))
                .Distance;
        }

        public int SolvePart2()
        {
            throw new NotImplementedException();
        }

        private class Route
        {
            public string Location1 { get; set; }
            public string Location2 { get; set; }
            public int Distance { get; set; }

            public Route(string s)
            {
                var splits = s.Split(new char[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);
                Location1 = splits[0];
                Location2 = splits[2];
                Distance = int.Parse(splits[3]);
            }
        }
    }
}
