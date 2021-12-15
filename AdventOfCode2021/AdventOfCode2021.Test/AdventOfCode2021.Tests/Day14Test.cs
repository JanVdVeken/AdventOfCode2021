using System.IO;
using System.Linq;
using Day14;
using Xunit;

namespace DaysTest
{
    public class Day14Test
    {
        private readonly Day14.Day14 _day;
        private readonly string _testInputLocation;

        public Day14Test()
        {
            _day = new Day14.Day14();
            _testInputLocation =
                @"../../../../../AdventOfCode2021.Test/AdventOfCode2021.Tests/TestInputs/D14.txt";
        }

        [Fact]
        public void CtorPolymerization_WithTestInput_ShouldCreateOneStartAndOneList()
        {
            var testInput = File.ReadLines(_testInputLocation).ToList();
            
            var polymerization = new Polymerization(testInput);
            
            Assert.Equal(16,polymerization.PairInsertions.Count);
        }
        [Theory]
        [InlineData(0,1)]
        [InlineData(1,1)]
        public void Polymerization_WithTestDataAndXStep_GetsCorrectLenght(int amount,int expected)
        {
            var testInput = File.ReadLines(_testInputLocation).ToList();
            var polymerization = new Polymerization(testInput);
            
            polymerization.Step(amount);
            
            Assert.Equal(expected,polymerization.CalculateMostMinusFewest());
        }
        
        [Fact]
        void P1_WithTestData_ShouldReturnCorrectValue()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _day.Puzzle1(testInput);
            
            Assert.Equal("1588", result);
        }

        [Fact]
        void P2_WithTestData_ShouldReturnCorrectValue()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _day.Puzzle2(testInput);
            
            Assert.Equal("2188189693529", result);
        }
    }
}