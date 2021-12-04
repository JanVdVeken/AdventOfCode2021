using System;
using System.Collections.Generic;
using System.Linq;
using Shared;
using Days;

namespace AdventOfCode2021
{
    class Program
    {
        public static List<Day> Days = new()
        {
            new Day01(),
            new Day02(),
            new Day03(),
            new Day04(),
            new Day05()
        };
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Which Day do you want ?");
                Days.Where(x => x.Title != null).ToList().ForEach(x => x.PrintInfo());
                var input = Console.ReadLine();
                if (int.TryParse(input, out var chosenDay) && Days.SingleOrDefault(x => x.DayNumber == chosenDay) != null)
                {
                    var day = Days.Single(x => x.DayNumber == chosenDay);
                    day.HandleSelect();
                    day.Deselect();
                }
                else
                {
                    Console.WriteLine("Day not found, Press Key to go back to main menu");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}