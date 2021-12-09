using System.Collections.Generic;
using System.IO;
using Day09;
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
            
            Assert.Equal("15", result);
        }

        [Fact]
        void CtorCave_WithInput2by2_ShouldReturnCorrectOutput()
        {
            var input = new List<string>() {"99", "91"};
            var cave = new Cave(input);
            
            cave.CalculateLowestPoints();
            
            Assert.Equal(2,cave.SumOfLowestPoints());
        }
        [Fact]
        void CtorCave_WithInput3by3_ShouldReturnCorrectOutput()
        {
            var input = new List<string>() {"191", "919","191"};
            var cave = new Cave(input);
            
            cave.CalculateLowestPoints();
            
            Assert.Equal(10,cave.SumOfLowestPoints());
        }

        [Fact]
        void P2_WithTestData_ShouldReturnCorrectValue()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _day.Puzzle2(testInput);
            
            Assert.Equal("1134", result);
        }
    }
}