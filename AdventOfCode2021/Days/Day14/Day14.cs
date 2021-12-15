using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Day14
{
    public class Day14 : Day
    {
        public Day14()
        {
            Title = "Extended Polymerization";
            DayNumber = 14;
        }
        public override string Puzzle1(IEnumerable<string> inputsString)
        {
            var polymerization = new Polymerization(inputsString.ToList());
        
            polymerization.Step(10);
            
            return polymerization.CalculateMostMinusFewest().ToString();
        }

        public override string Puzzle2(IEnumerable<string> inputsString)
        {
            var polymerization = new Polymerization(inputsString.ToList());
        
            polymerization.Step(40);
            
            return polymerization.CalculateMostMinusFewest().ToString();
        }
    }
}