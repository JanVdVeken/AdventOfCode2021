using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Shared
{
    public abstract class Day
    {
        public string Title;
        public int DayNumber;

        public void PrintInfo()
        {
            Console.WriteLine($"{DayNumber}. {Title}");
        }
        public void HandleSelect()
        {
            Console.WriteLine("Do you want to solve Part 1 or 2?");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine(Puzzle1(GatherInput()));
                    break;
                case "2":
                    Console.WriteLine(Puzzle2(GatherInput()));
                    break;
                default:
                    Console.WriteLine($"Not implemented");
                    HandleSelect();
                    break;
            }
        }

        public void Deselect()
        {
            Console.WriteLine("Press Key to go back to main menu");
            Console.ReadKey();
            Console.Clear();
        }
        protected IEnumerable<string> ReadFile()
        {
            DirectoryInfo inputs = new DirectoryInfo(Directory.GetCurrentDirectory() + @"..\..\..\..\..\Inputs\");
            var daynumberString = "00" + DayNumber;
            daynumberString = ("00" + DayNumber).Substring(daynumberString.Length -2);
            var inputFile = inputs.FullName + $"D{daynumberString}.txt";
            return File.ReadAllLines(inputFile );
        }

        public IEnumerable<string> GatherInput()
        {
            var inputs = ReadFile().ToList();
            return inputs;
        }

        public abstract string Puzzle1(IEnumerable<string> inputsString);

        public abstract string Puzzle2(IEnumerable<string> inputsString);
    }
}
