using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Days
{
    public class Day05 : Day
    {
        public Day05()
        {
            Title = "Hydrothermal Venture";
            DayNumber = 5;
        }
        public override string Puzzle1(IEnumerable<string> inputsString)
        {
            var lines = new List<Line>();
            inputsString.ToList().ForEach(x => lines.Add(new Line(x)));
            Dictionary<Point, int> locations = new Dictionary<Point, int>(new PointEqualityComparer());
            foreach (var points in lines.Where(x =>x.IsVerticalOrHorizontal()).Select(x => x.ReturnAllPointsOnLine()))
            {
                foreach (var point in points)
                {
                    if (locations.ContainsKey(point)) locations[point] += 1;
                    else
                    {
                        locations.Add(point,1);
                    }
                }
            }

            return locations.Values.Count(x => x >= 2).ToString();
        }

        public override string Puzzle2(IEnumerable<string> inputsString)
        {
            throw new System.NotImplementedException();
        }
    }
}