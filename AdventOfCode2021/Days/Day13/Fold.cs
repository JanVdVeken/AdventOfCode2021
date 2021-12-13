using System.Linq;

namespace Day13
{
    public class Fold
    {
        public char Axis;
        public int Amount;
        public Fold(string inputstring)
        {
            var replace = inputstring.Replace("fold along ","");
            var split = replace.Split("=");
            Axis = split[0].First();
            Amount = int.Parse(split[1]);
        }
    }
}