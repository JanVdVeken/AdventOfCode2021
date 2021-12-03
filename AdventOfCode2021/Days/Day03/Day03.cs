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
            binaryInterpreter.StartPowerConsumptionCalculation();
            return binaryInterpreter.PowerConsumption().ToString();
        }

        public override string Puzzle2(IEnumerable<string> inputsString)
        {
            BinaryInterpreter binaryInterpreter = new BinaryInterpreter(inputsString.ToList());
            binaryInterpreter.StartLifeSupportCalculations();
            return binaryInterpreter.LiveSupportRating().ToString();        }
    }
}