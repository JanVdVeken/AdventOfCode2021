using System.IO;
using Day10;
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

        [Fact]
        void P2_WithTestData_ShouldReturnCorrectValue()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _day.Puzzle2(testInput);
            
            Assert.Equal("288957", result);
        }

        [Fact]
        void SyntaxCalculateIncompled_WithOneTestDataLine_ShouldReturnCorrectValue()
        {
            var syntax = new SyntaxLine("<{([{{}}[<[[[<>{}]]]>[]]");
            
            syntax.CalculateSyntax();
            
            Assert.Equal(294,syntax.ValueOfIncompletedSyntax());
        }
        
    }
}