using System.IO;
using System.Linq;
using System.Reflection;
using Days;
using Xunit;

namespace DaysTest
{
    public class Day06Test
    {
        private readonly Day06 _do6;
        private readonly string _testInputLocation;

        public Day06Test()
        {
            _do6 = new Day06();
            _testInputLocation =
                @"../../../../../AdventOfCode2021.Test/AdventOfCode2021.Tests/TestInputs/D06.txt";
        }
        [Fact]
        void P1_WithTestData_Returns5934()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _do6.Puzzle1(testInput);
            
            Assert.Equal("5934", result);
        }
    }
}