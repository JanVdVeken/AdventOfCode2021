using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Shared;

namespace Day10
{
    public class Day10 : Day
    {
        public Day10()
        {
            Title = "Syntax Scoring";
            DayNumber = 10;
        }
        public override string Puzzle1(IEnumerable<string> inputsString)
        {
            var syntaxes = new List<SyntaxLine>();
            inputsString.ToList().ForEach(x => syntaxes.Add(new SyntaxLine(x)));
            syntaxes.ForEach(x => x.CalculateSyntax());
            return syntaxes.Sum(x => x.ValueOfWrongCharacter()).ToString();
        }

        public override string Puzzle2(IEnumerable<string> inputsString)
        {
            throw new System.NotImplementedException();
        }
    }
}