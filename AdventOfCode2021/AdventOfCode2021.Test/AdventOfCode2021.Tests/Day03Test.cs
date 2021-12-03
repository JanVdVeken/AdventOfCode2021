using System.IO;
using Xunit;

namespace Day03.Test
{
    public class Day03Test
    {
        private readonly Days.Day03 _d03;
        private readonly string _testInputLocation;

        public Day03Test()
        {
            _d03 = new Days.Day03();
            _testInputLocation =
                @"../../../../../AdventOfCode2021.Test/AdventOfCode2021.Tests/TestInputs/D03.txt";
            
        }

        [Fact]
        void P1_WithTestData_Returns198()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _d03.Puzzle1(testInput);
            
            Assert.Equal("198", result);
        }
        [Fact]
        void P2_WithTestData_Returns230()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _d03.Puzzle2(testInput);
            
            Assert.Equal("230", result);
        }
        
    }
}