using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Day24
{
    public class TileNavigationReader
    {
        public List<List<Direction>> ReadSteps(string filename)
        {
            var stepList = new List<List<Direction>>();

            var lines = File.ReadAllLines(filename);

            foreach (var line in lines)
            {
                var steps = ReadLine(line);
                stepList.Add(steps);
            }

            return stepList;
        }

        public List<Direction> ReadLine(string line)
        {
            //var stepList = new List<string>();

            // pointy tile (point at top/bottom, not horizontal at top/bottom)
            var regex = new Regex(@"(ne|se|sw|nw|e|w)+?");

            var matches = regex.Matches(line);

            if (matches.Count == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return matches.Cast<Match>().Select(m => ConvertToDirection(m.Value.ToString())).ToList();
        }


        public Direction ConvertToDirection(string step)
        {
            return (Direction)Enum.Parse(typeof(Direction), step, true);
        }
    }
}
