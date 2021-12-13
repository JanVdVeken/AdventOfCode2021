using System.IO;
using Xunit;

namespace DaysTest
{
    public class Day14Test
    {
        private readonly Day14.Day14 _day;
        private readonly string _testInputLocation;

        public Day14Test()
        {
            _day = new Day14.Day14();
            _testInputLocation =
                @"../../../../../AdventOfCode2021.Test/AdventOfCode2021.Tests/TestInputs/D14.txt";
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