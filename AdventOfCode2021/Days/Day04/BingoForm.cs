using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mime;
using System.Runtime.Serialization;

namespace Days
{
    public class BingoForm
    {
        private static int _size = 5;
        public FormCell[,] Form { get; set; }

        public BingoForm()
        {
            Form = new FormCell[_size, _size];
        }
        public BingoForm(List<string> input)
        {
            Form = new FormCell[_size, _size];
            for(int i =0;i<input.Count;i++)
            {
                var cellElements = input[i].Split(" ")
                        .Where(x => !string.IsNullOrEmpty(x))
                        .Select(int.Parse)
                        .ToList();
                for (int y = 0; y < cellElements.Count(); y++)
                { 
                    Form[i, y] = new FormCell(cellElements[y],false);
                }
            }
        }
        public void NewNumber(int number)
        {
            foreach (var cell in Form)
            {
                if (cell.Value == number) cell.Visited = true;
            }
        }

        public int WinningValue()
        {
            int value = 0;
            foreach (var cell in Form)
            {
                value += cell.Visited ? 0 : cell.Value;
            }
            return value;
        }
        
        public bool CheckIfFormIsCompletedRowsColumns()
        {
            return CheckWinningRow() | CheckWinningColumns();
        }

        public bool CheckWinningRow()
        {
            for(int i = 0;i<_size;i++)
            {
                bool winningRow = true;
                for (int j = 0; j < _size; j++)
                {
                    winningRow &= Form[i, j].Visited;
                }
                if (winningRow) return true;
            }

            return false;
        }

        public bool CheckWinningColumns()
        {
            for(int i = 0;i<_size;i++)
            {
                bool winningColumn = true;
                for (int j = 0; j < _size; j++)
                {
                    winningColumn &= Form[j, i].Visited;
                }
                if (winningColumn) return true;
            }
            return false;
        }

        public void Print()
        {
            for(int i = 0;i<_size;i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Console.Write(Form[i,j].Value + " ");
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
        
    }
}