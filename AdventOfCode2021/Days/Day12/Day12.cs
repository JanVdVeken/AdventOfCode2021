using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Day12
{
    public class Day12 : Day
    {
        public Day12()
        {
            Title = "Passage Pathing";
            DayNumber = 12;
        }
        public override string Puzzle1(IEnumerable<string> inputsString)
        {
            var cave = new CaveSystem(inputsString.ToList());
            cave.CalculateAllPathsWithoutDoubleLowerCasesWithStartingPoint();
            return cave.Count.ToString();
        }

        public override string Puzzle2(IEnumerable<string> inputsString)
        {
            var cave = new CaveSystem(inputsString.ToList());
            cave.CalculateAllPathsWithOneDoubleLowerCaseWithStartingPoint();
            return cave.Count.ToString();        
        }
    }
}