using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using System.Threading.Channels;

namespace Days
{
    public class BingoController
    {
        public readonly List<BingoForm> Forms;
        private readonly List<int> _inputDigits;
        private int _lastCalledNumber;

        public BingoController(List<string> inputs)
        {
            Forms = new List<BingoForm>();
            _inputDigits = inputs[0].Split(",").ToList().Select(int.Parse).ToList();
            var currentListOfLines = new List<string>();
            foreach(var line in inputs.Skip(2))
            {
                if (line.Equals(string.Empty))
                {
                    Forms.Add(new BingoForm(currentListOfLines));
                    currentListOfLines = new List<string>();
                }
                else
                {
                    currentListOfLines.Add(line);
                }
                
            }
        }
        
        public void PlayBingo()
        {
            foreach (int number in _inputDigits)
            {
                while (!Forms.Any(form => form.CheckIfFormIsCompletedRowsColumns()))
                {
                    Forms.ForEach(x => x.NewNumber(number));
                    _lastCalledNumber = number;
                }
            }
        }

        public int GetWinningFormValue()
        {
            return Forms.First(x => x.CheckIfFormIsCompletedRowsColumns()).WinningValue() * _lastCalledNumber;
        }

        public void PrintAllForms()
        {
            Forms.ForEach(x => x.Print());
        }
    }
}