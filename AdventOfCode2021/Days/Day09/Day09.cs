using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Day09
{
    public class Day09 : Day
    {
        public Day09()
        {
            Title = "Smoke Basin";
            DayNumber = 9;
        }
        public override string Puzzle1(IEnumerable<string> inputsString)
        {
            var cave = new Cave(inputsString.ToList());
            cave.CalculateLowestPoints();
            return cave.SumOfLowestPoints().ToString();
        }

        public override string Puzzle2(IEnumerable<string> inputsString)
        {
            throw new System.NotImplementedException();
        }
    }
}