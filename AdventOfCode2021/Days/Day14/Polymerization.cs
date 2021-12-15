using System.Collections.Generic;
using System.Linq;

namespace Day14
{
    public class Polymerization
    {
        public readonly List<PairInsertion> PairInsertions;
        private Dictionary<string, int> _polymerCount;
        private Dictionary<char, long> _singleElementDict;

        public Polymerization(List<string> inputs)
        {
            PairInsertions = new List<PairInsertion>();
            _polymerCount = new Dictionary<string, int>();
            _singleElementDict = new Dictionary<char, long>();
            foreach (string input in inputs.Where(x => !x.Equals(string.Empty)))
            {
                if (!input.Contains("->"))
                {
                    for (int i = 0; i < input.Length - 1; i++)
                    {
                        AddToDict(input.Substring(i, 2), 1, _polymerCount);
                    }
                    for (int i = 0; i < input.Length; i++)
                    {
                        AddToDict(input[i], 1, _singleElementDict);
                    }
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
                var newDictionary = new Dictionary<string, int>();
                foreach (var key in _polymerCount.Keys)
                {
                    var currentPair = PairInsertions.First(x => x.From.Equals(key));
                    foreach (var pair in currentPair.GetTwoToPairs())
                    {
                        AddToDict(pair,_polymerCount[key],newDictionary);
                    }
                    AddToDict(currentPair.To,_polymerCount[key],_singleElementDict);
                }
                _polymerCount = new Dictionary<string, int>(newDictionary);
            }
        }

        public long CalculateMostMinusFewest()
        {
            return _singleElementDict.Values.Max() - _singleElementDict.Values.Min();
        }
        
        public void AddToDict(string key,int value, Dictionary<string, int > dict)
        {
            if (dict.Keys.Contains(key)) dict[key] += value;
            else dict[key] = value;
        }
        public void AddToDict(char key,long value, Dictionary<char, long>? dict)
        {
            if (dict.Keys.Contains(key)) dict[key] += value;
            else dict[key] = value;
        }
    }
}