using System.IO;
using Xunit;

namespace DaysTest
{
    public class Day10Test
    {
        private readonly Day10.Day10 _day;
        private readonly string _testInputLocation;

        public Day10Test()
        {
            _day = new Day10.Day10();
            _testInputLocation =
                @"../../../../../AdventOfCode2021.Test/AdventOfCode2021.Tests/TestInputs/D10.txt";
        }
        
        [Fact]
        void P1_WithTestData_ShouldReturnCorrectValue()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _day.Puzzle1(testInput);
            
            Assert.Equal("26397", result);
        }

        void P2_WithTestData_ShouldReturnCorrectValue()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _day.Puzzle2(testInput);
            
            Assert.Equal("", result);
        }
    }
}