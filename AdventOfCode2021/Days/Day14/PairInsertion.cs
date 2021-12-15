using System.Collections.Generic;
using System.Linq;

namespace Day14
{
    public class PairInsertion
    {
        public string From;
        public char To;

        public PairInsertion(string from, char to)
        {
            From = from;
            To = to;
        }

        public PairInsertion(string input)
        {
            var temp = input.Split(" -> ");
            From = temp[0];
            To = temp[1].First();
        }

        public List<string> GetTwoToPairs()
        {
            return new List<string>(){$"{From[0]}{To}",$"{To}{From[1]}"};
        }
    }
}