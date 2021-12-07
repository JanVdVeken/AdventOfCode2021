using System.Collections.Generic;
using System.IO;
using Day08;
using Xunit;

namespace DaysTest
{
    public class Day08Test
    {
        private readonly Day08.Day08 _day;
        private readonly string _testInputLocation;

        public Day08Test()
        {
            _day = new Day08.Day08();
            _testInputLocation =
                @"../../../../../AdventOfCode2021.Test/AdventOfCode2021.Tests/TestInputs/D08.txt";
        }
        
        void P1_WithTestData_ShouldReturnCorrectValue()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _day.Puzzle1(testInput);
            
            Assert.Equal("37", result);
        }
        
        
        void P2_WithTestData_ShouldReturnCorrectValue()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _day.Puzzle2(testInput);
            
            Assert.Equal("168", result);
        }
    }
}