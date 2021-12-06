using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Days
{
    public class Day06 : Day
    {
        public Day06()
        {
            Title = "Lanternfish";
            DayNumber = 6;
        }
        public override string Puzzle1(IEnumerable<string> inputsString)
        {
            var inputs = inputsString.ToList().First().Split(",").ToList().Select(x => int.Parse(x));
            var school = new School(inputs.ToList());
            school.SimulateDays(80);
            return school.GetSchoolSize().ToString();
        }

        public override string Puzzle2(IEnumerable<string> inputsString)
        {
            var inputs = inputsString.ToList().First().Split(",").ToList().Select(x => int.Parse(x));
            var school = new School(inputs.ToList());
            school.SimulateDays(256);
            return school.GetSchoolSize().ToString();
        }
    }
}