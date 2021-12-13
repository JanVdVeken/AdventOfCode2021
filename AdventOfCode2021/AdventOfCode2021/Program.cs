using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared;

namespace AdventOfCode2021
{
    class Program
    {
        public static List<Day> Days = new()
        {
            new Day01.Day01(),
            new Day02.Day02(),
            new Day03.Day03(),
            new Day04.Day04(),
            new Day05.Day05(),
            new Day06.Day06(),
            new Day07.Day07(),
            new Day08.Day08(),
            new Day09.Day09(),
            new Day10.Day10(),
            new Day11.Day11(),
            new Day12.Day12(),
            new Day13.Day13()
        };
        static Task Main(string[] args)
        {
            GetInputService.GetInputService.GetInputs();
            Console.Title = "Advent Of Code 2021";
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