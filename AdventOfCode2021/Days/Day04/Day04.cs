using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using Shared;

namespace Days
{
    public class Day04 : Day
    {
        public Day04()
        {
            DayNumber = 4;
            Title = "Giant Squid";
        }

        public override string Puzzle1(IEnumerable<string> inputsString)
        {
            BingoController controller = new BingoController(inputsString.ToList());
            controller.PlayBingo();
            return controller.GetWinningFormValue().ToString();
        }

        public override string Puzzle2(IEnumerable<string> inputsString)
        {
            BingoController controller = new BingoController(inputsString.ToList());
            controller.PlayBingoToLose();
            return controller.GetLosingFormValue().ToString();        }
    }
}