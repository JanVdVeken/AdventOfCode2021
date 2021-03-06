using System.Collections.Generic;
using System.IO;
using Day07;
using Xunit;

namespace DaysTest
{
    public class Day07Test
    {
        private readonly Day07.Day07 _day;
        private readonly string _testInputLocation;

        public Day07Test()
        {
            _day = new Day07.Day07();
            _testInputLocation =
                @"../../../../../AdventOfCode2021.Test/AdventOfCode2021.Tests/TestInputs/D07.txt";
        }
        [Fact]
        void P1_WithTestData_ShouldReturnCorrectValue()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _day.Puzzle1(testInput);
            
            Assert.Equal("37", result);
        }

        [Fact]
        void IncrementingFuelUsage_Withinput11_ShouldReturn66()
        {
            var distance = 11;

            var result = _day.IncrementingFuelUsage(11);
            
            Assert.Equal(66,result);
        }
        [Fact]
        void P2_WithTestData_ShouldReturnCorrectValue()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _day.Puzzle2(testInput);
            
            Assert.Equal("168", result);
        }
    }
}