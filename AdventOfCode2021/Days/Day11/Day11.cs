using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Day11
{
    public class Day11 : Day
    {
        public Day11()
        {
            Title = "Dumbo Octopus";
            DayNumber = 11;
        }
        public override string Puzzle1(IEnumerable<string> inputsString)
        {
            var octopusGrid = new OctopusGrid(inputsString.ToList());
            
            octopusGrid.CalculateFlashes(100);

            return octopusGrid.Flashes.ToString();

        }

        public override string Puzzle2(IEnumerable<string> inputsString)
        {
            throw new System.NotImplementedException();
        }
    }
}