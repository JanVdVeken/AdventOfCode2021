using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Days
{
    public class Day03 : Day
    {
        public Day03()
        {
            DayNumber = 3;
            Title = "Binary Diagnostic";
        }
        public override string Puzzle1(IEnumerable<string> inputsString)
        {
            BinaryInterpreter binaryInterpreter = new BinaryInterpreter(inputsString.ToList());
            binaryInterpreter.StartInterpretation();
            return binaryInterpreter.PowerConsumption().ToString();
        }

        public override string Puzzle2(IEnumerable<string> inputsString)
        {
            throw new System.NotImplementedException();
        }
    }
}