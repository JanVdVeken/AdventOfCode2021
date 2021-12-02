using System.Collections.Generic;
using Shared;

namespace Days
{
    public class Day02 : Day
    {
        public Day02()
        {
            DayNumber = 2;
            Title = "Dive!";
        }
        public override string Puzzle1(IEnumerable<string> inputsString)
        {
            Submarine sub = new Submarine(0, 0);
            List<Command> commands = new List<Command>();
            foreach (var line in inputsString)
            {
                commands.Add(new Command(line.Split(" ")[0],int.Parse(line.Split(" ")[1])));
            }
            commands.ForEach(x => sub.Move(x));
            return sub.CalcPosition().ToString();
        }

        public override string Puzzle2(IEnumerable<string> inputsString)
        {
            Submarine sub = new Submarine(0, 0);
            List<Command> commands = new List<Command>();
            foreach (var line in inputsString)
            {
                commands.Add(new Command(line.Split(" ")[0],int.Parse(line.Split(" ")[1])));
            }
            commands.ForEach(x => sub.ReAim(x));
            return sub.CalcPosition().ToString();
        }
    }
}