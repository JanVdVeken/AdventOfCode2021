using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Day13
{
    public class Day13 : Day
    {
        public Day13()
        {
            Title = "Transparent Origami";
            DayNumber = 13;
        }
        public override string Puzzle1(IEnumerable<string> inputsString)
        {
            var origami = new OrigamiPaper(inputsString.ToList());

            return origami.CountPointsAfterTheFirstFold().ToString();
        }

        public override string Puzzle2(IEnumerable<string> inputsString)
        {
            throw new System.NotImplementedException();
        }
    }
}