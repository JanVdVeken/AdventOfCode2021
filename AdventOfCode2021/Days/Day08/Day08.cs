using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using Shared;

namespace Day08
{
    public class Day08 : Day
    {
        public Day08()
        {
            Title = "Seven Segment Search";
            DayNumber = 8;
        }
        public override string Puzzle1(IEnumerable<string> inputsString)
        {
            var count = inputsString
                .ToList()
                .Select(x => x.Split(" | ")[1]).ToList()
                .Select(x => x.Split(" "))
                .Sum(y => 
                        y.Count(x => x.Length == 2 | x.Length == 4 | x.Length == 3 | x.Length == 7)
                );
            return count.ToString();
        }

        public override string Puzzle2(IEnumerable<string> inputsString)
        {
            var sevenSegmentDisplays = new List<SevenSegmentDisplay>();
            inputsString.ToList().ForEach(line => sevenSegmentDisplays.Add(new SevenSegmentDisplay(line)));
            sevenSegmentDisplays.ForEach( x => x.CalculateConnections());
            return sevenSegmentDisplays.Sum(x => x.GetValueOfOutput()).ToString();
        }
    }
}