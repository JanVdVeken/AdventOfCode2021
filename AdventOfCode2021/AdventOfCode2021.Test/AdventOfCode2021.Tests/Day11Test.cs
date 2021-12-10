using System.IO;
using Xunit;

namespace DaysTest
{
    public class Day11Test
    {
        private readonly Day11.Day11 _day;
        private readonly string _testInputLocation;

        public Day11Test()
        {
            _day = new ();
            _testInputLocation =
                @"../../../../../AdventOfCode2021.Test/AdventOfCode2021.Tests/TestInputs/D11.txt";
        }
        
        void P1_WithTestData_ShouldReturnCorrectValue()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _day.Puzzle1(testInput);
            
            Assert.Equal("", result);
        }

        void P2_WithTestData_ShouldReturnCorrectValue()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _day.Puzzle2(testInput);
            
            Assert.Equal("", result);
        }
    }
}