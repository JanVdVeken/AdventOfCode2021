using System.Collections.Generic;
using System.Linq;
using Shared.Extensions;

namespace Day14
{
    public class Polymerization
    {
        public readonly List<PairInsertion> PairInsertions;
        private Dictionary<string,long> _polymerCount;
        private char _lastLetter;

        public Polymerization(List<string> inputs)
        {
            PairInsertions = new List<PairInsertion>();
            _polymerCount = new Dictionary<string, long>();
            foreach (string input in inputs.Where(x => !x.Equals(string.Empty)))
            {
                if (!input.Contains("->"))
                {
                    for (int i = 0; i < input.Length - 1; i++)
                    {
                        _polymerCount.AddToDictWithCheckOnExistingKey(input.Substring(i, 2), 1);
                    }
                    _lastLetter = input.Last();
                }
                else
                {
                    PairInsertions.Add(new PairInsertion(input));
                }
            }
            
        }

        public void Step(int amount)
        {
            for (int i = 0; i < amount; i ++)
            {
                var newDictionary = new Dictionary<string, long>();
                foreach (var key in _polymerCount.Keys)
                {
                    var currentPair = PairInsertions.First(x => x.From.Equals(key));
                    foreach (var pair in currentPair.GetTwoToPairs())
                    {
                        newDictionary.AddToDictWithCheckOnExistingKey(pair,_polymerCount[key]);
                    }
                }
                _polymerCount = new Dictionary<string, long>(newDictionary);
            }
        }

        public long CalculateMostMinusFewest()
        {
            var temp = new Dictionary<char, long>();
            foreach (var key in _polymerCount.Keys)
            {
                temp.AddToDictWithCheckOnExistingKey(key[0],_polymerCount[key]);
            }
            temp.AddToDictWithCheckOnExistingKey(_lastLetter,1);
            return temp.Values.Max() - temp.Values.Min(); 
        }
    }
}