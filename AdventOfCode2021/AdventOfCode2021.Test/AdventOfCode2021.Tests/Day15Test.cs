using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using Day15;
using Xunit;

namespace DaysTest
{
    public class Day15Test
    {
        private readonly Day15.Day15 _day;
        private readonly string _testInputLocation;

        public Day15Test()
        {
            _day = new Day15.Day15();
            _testInputLocation =
                @"../../../../../AdventOfCode2021.Test/AdventOfCode2021.Tests/TestInputs/D15.txt";
        }
        
        void P1_WithTestData_ShouldReturnCorrectValue()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _day.Puzzle1(testInput);
            
            Assert.Equal("40", result);
        }

        void P2_WithTestData_ShouldReturnCorrectValue()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _day.Puzzle2(testInput);
            
            Assert.Equal("", result);
        }
    }
}