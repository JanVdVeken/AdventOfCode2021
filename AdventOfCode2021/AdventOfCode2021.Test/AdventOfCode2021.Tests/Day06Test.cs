using System.Collections.Generic;
using System.IO;
using Day06;
using Xunit;

namespace DaysTest
{
    public class Day06Test
    {
        private readonly Day06.Day06 _do6;
        private readonly string _testInputLocation;

        public Day06Test()
        {
            _do6 = new Day06.Day06();
            _testInputLocation =
                @"../../../../../AdventOfCode2021.Test/AdventOfCode2021.Tests/TestInputs/D06.txt";
        }

        [Fact]
        void School_WithFishOnDayZero_ShouldReproduce()
        {
            var testInput = new List<int>(){0,0};
            var testSchool = new School(testInput);
            
            testSchool.SimulateDays(1);
            
            Assert.Equal(new long[]{0,0,0,0,0,0,2,0,2},testSchool.GetArray());

        }
        [Fact]
        void P1_WithTestData_Returns5934()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _do6.Puzzle1(testInput);
            
            Assert.Equal("5934", result);
        }
        [Fact]
        void P2_WithTestData_Returns26984457539()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _do6.Puzzle2(testInput);
            
            Assert.Equal("26984457539", result);
        }
    }
}