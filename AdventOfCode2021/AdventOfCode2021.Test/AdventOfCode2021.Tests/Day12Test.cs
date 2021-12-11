using System.IO;
using Xunit;

namespace DaysTest
{
    public class Day12Test
    {
        private readonly Day12.Day12 _day;
        private readonly string _testInputLocation;

        public Day12Test()
        {
            _day = new Day12.Day12();
            _testInputLocation =
                @"../../../../../AdventOfCode2021.Test/AdventOfCode2021.Tests/TestInputs/D12.txt";
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