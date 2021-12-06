using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Day01
{
    public class Day01 : Day
    {
        public Day01()
        {
            DayNumber = 1;
            Title = "Sonar Sweep";
        }
        public override string Puzzle1(IEnumerable<string> inputsString)
        {
            var inputs = inputsString.Select(x => int.Parse(x)).ToList();
            int count = 0;
            for (int i = 1; i < inputs.Count(); i++)
            {
                count += inputs[i] > inputs[i - 1] ? 1 : 0;
            }

            return count.ToString();
        }

        public override string Puzzle2(IEnumerable<string> inputsString)
        {
            var inputs = inputsString.Select(x => int.Parse(x)).ToList();
            int count = 0;
            for (int i = 3; i < inputs.Count(); i++)
            {
                count += inputs[i] > inputs[i - 3] ? 1 : 0;
            }
            return count.ToString();
        }
    }
}