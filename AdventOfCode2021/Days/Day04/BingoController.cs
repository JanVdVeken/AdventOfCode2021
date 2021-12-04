using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using System.Threading.Channels;

namespace Days
{
    public class BingoController
    {
        public readonly List<BingoForm> Forms;
        private readonly List<int> _BingoNumbers;
        private int _lastCalledNumber;
        private BingoForm lastWinningForm;

        public BingoController(List<string> inputs)
        {
            Forms = new List<BingoForm>();
            _BingoNumbers = inputs[0].Split(",").ToList().Select(int.Parse).ToList();
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
            Forms.Add(new BingoForm(currentListOfLines));
            
        }
        
        public void PlayBingo()
        {
            foreach (int number in _BingoNumbers)
            {
                Forms.ForEach(x => x.NewNumber(number));
                _lastCalledNumber = number;
                if (Forms.Any(form => form.CheckIfFormIsCompletedRowsColumns())) break;
            }
        }
        public void PlayBingoToLose()
        {
            for(int i =0; i<_BingoNumbers.Count();i++)
            {
                
                var number = _BingoNumbers[i];
                Forms.ForEach(x => x.NewNumber(number));
                var count = Forms.Count- Forms.Count(x => x.CheckIfFormIsCompletedRowsColumns());
                if (count == 1)
                {
                    int j = 1;
                    while (true)
                    {
                        _lastCalledNumber = _BingoNumbers[i +j];
                        Console.WriteLine(_lastCalledNumber);
                        lastWinningForm = Forms.First(x => !x.CheckIfFormIsCompletedRowsColumns());
                        lastWinningForm.NewNumber(_lastCalledNumber);
                        if (Forms.Count - Forms.Count(x => x.CheckIfFormIsCompletedRowsColumns()) == 0) break;
                        j++;
                    }
                    break;
                };
            }
        }

        public int GetLosingFormValue()
        {
            return lastWinningForm.WinningValue() * _lastCalledNumber;
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