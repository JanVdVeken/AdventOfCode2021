using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Shared;

namespace Day07
{
    public class Day07 : Day
    {
        public Day07()
        {
            Title = "The Treachery of Whales";
            DayNumber = 7;
        }
        public override string Puzzle1(IEnumerable<string> inputsString)
        {
            var distances = inputsString.Single()
                .Split(",")
                .ToList()
                .Select(x => int.Parse(x))
                .ToList();
            var minValue = distances.Min();
            var maxValue = distances.Max();
            var minFuelUsage = int.MaxValue;
            for (int i = minValue; i <= maxValue; i++)
            {
                int currentUsage = 0;
                foreach (var distance in distances)
                {
                    currentUsage += Math.Abs(i - distance);
                }

                minFuelUsage = Math.Min(currentUsage, minFuelUsage);
            }

            return minFuelUsage.ToString();
        }

        public override string Puzzle2(IEnumerable<string> inputsString)
        {
            var distances = inputsString.Single()
                .Split(",")
                .ToList()
                .Select(x => int.Parse(x))
                .ToList();
            var minValue = distances.Min();
            var maxValue = distances.Max();
            long minFuelUsage = long.MaxValue;
            for (int i = minValue; i <= maxValue; i++)
            {
                long currentUsage = 0;
                foreach (var distance in distances)
                {
                    currentUsage += IncrementingFuelUsage(Math.Abs( i - distance));
                }

                minFuelUsage = Math.Min(currentUsage, minFuelUsage);
            }

            return minFuelUsage.ToString();
        }

        public long IncrementingFuelUsage(long input)
        {
            //sum of natural numbers
            return input * (input + 1) / 2;
            // if (input == 1) return 1;
            // return IncrementingFuelUsage(input - 1) + input;
        }
    }
}