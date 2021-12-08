using System.Collections.Generic;
using System.Linq;

namespace Day08
{
    public class SevenSegmentDisplay
    {
        public List<string> Inputs;
        public List<string> Outputs;
        private Dictionary<string, int> _mapping;

        public SevenSegmentDisplay(string line)
        {
            _mapping = new Dictionary<string, int>();
            Inputs = line.Split(" | ")[0]
                .Split(" ").ToList()
                .Select(x => string.Concat(x.OrderBy(c => c)))
                .ToList();
            Outputs = line.Split(" | ")[1]
                 .Split(" ").ToList()
                .Select(x => string.Concat(x.OrderBy(c => c)))
                .ToList();
        }

        public void CalculateConnections()
        {
            _mapping.Add(Inputs.First(x => x.Length ==2),1);
            _mapping.Add(Inputs.First(x => x.Length ==4),4);
            _mapping.Add(Inputs.First(x => x.Length ==3),7);
            _mapping.Add(Inputs.First(x => x.Length ==7),8);
            foreach (var input in Inputs.Where(x => x.Length == 6))
            {
                var containsSeven = !_mapping.FirstOrDefault(x => x.Value == 7).Key.ToCharArray().Except(input.ToCharArray()).Any();
                var containsFour = !_mapping.FirstOrDefault(x => x.Value == 4).Key.ToCharArray().Except(input.ToCharArray()).Any();
                if (containsSeven & containsFour)
                {
                    // 9 has 6 characters and contains all the characters of 7 and all characters of 4
                    _mapping.Add(input,9);
                }
                else
                {
                    if (containsSeven)
                    {
                        // 6 has 6 characters and contains all the characters of 7 and not of 4
                        _mapping.Add(input, 0);
                    }
                    else
                    {
                        // 6 has 6 characters and does not contain all the characters of 4 and 7
                        _mapping.Add(input, 6);
                    }
                }
            }
            foreach (var input in Inputs.Where(x => x.Length == 5))
            {
                var fitsInSix = !input.ToCharArray().Except(_mapping.FirstOrDefault(x => x.Value == 6).Key.ToCharArray()).Any();
                var containsOne = !_mapping.FirstOrDefault(x => x.Value == 1).Key.ToCharArray().Except(input.ToCharArray()).Any();
                if (fitsInSix)
                {
                    // 5 has 5 characters and fits in 6
                    _mapping.Add(input,5);
                }
                else
                {
                    if (containsOne)
                    {
                        // 3 has 5 characters and doesn't fit in 6 and contains all characters of 1
                        _mapping.Add(input,3);
                    }
                    else
                    {
                        // 2 has 5 characters and doesn't fit in 6 and 1
                        _mapping.Add(input,2);
                    }
                }
            }
        }
        public int GetValueOfOutput()
        {
            var outPutString = "";
            Outputs.ForEach(x => outPutString += _mapping[x]);
            return int.Parse(outPutString);
        }
    }
}