using System.IO;
using Xunit;

namespace DaysTest
{
    public class Day09Test
    {
        private readonly Day09.Day09 _day;
        private readonly string _testInputLocation;

        public Day09Test()
        {
            _day = new Day09.Day09();
            _testInputLocation =
                @"../../../../../AdventOfCode2021.Test/AdventOfCode2021.Tests/TestInputs/D09.txt";
        }
        [Fact]
        void P1_WithTestData_ShouldReturnCorrectValue()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _day.Puzzle1(testInput);
            
            Assert.Equal("", result);
        }

        [Fact]
        void P2_WithTestData_ShouldReturnCorrectValue()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _day.Puzzle2(testInput);
            
            Assert.Equal("", result);
        }
    }
}