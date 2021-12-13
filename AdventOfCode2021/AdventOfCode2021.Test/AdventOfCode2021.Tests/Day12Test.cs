using System.Collections.Generic;
using System.IO;
using System.Linq;
using Day12;
using Xunit;

namespace DaysTest
{
    public class Day12Test
    {
        private readonly Day12.Day12 _day;
        private readonly string _testInputLocation;

        public Day12Test()
        {
            _day = new Day12.Day12();
            _testInputLocation =
                @"../../../../../AdventOfCode2021.Test/AdventOfCode2021.Tests/TestInputs/D12.txt";
        }

        [Fact]
        public void CtorCaveSystem_ShouldCreateListPoints()
        {
            var inputs = new List<string>() {"start-A"};
            var cave = new CaveSystem(inputs);
            
            Assert.Equal(2,cave.AllPoints.Count);
        }
        
        [Fact]
        public void CtorCaveSystem_ShouldCreateListPointsWithConnections()
        {
            var inputs = new List<string>() {"start-A"};
            var cave = new CaveSystem(inputs);

            var point = cave.AllPoints.First();
            
            Assert.Single(point.Connections);
        }
        [Fact]
        public void Point_WhenAddingExistingConnections_ShouldNotAddNewOne()
        {
            var p1 = new Point("a");
            var p2 = new Point("b");
            p1.AddToConnections(p2);
            
            p1.AddToConnections(p2);
            
            Assert.Single(p1.Connections);
        }

        [Theory]
        [InlineData(@"../../../../../AdventOfCode2021.Test/AdventOfCode2021.Tests/TestInputs/D12_01.txt", "19")]
        [InlineData(@"../../../../../AdventOfCode2021.Test/AdventOfCode2021.Tests/TestInputs/D12_02.txt", "226")]
        void P1_WithTestData_ShouldReturnCorrectValue(string input, string output)
        {
            var testInput = File.ReadLines(input);

            var result = _day.Puzzle1(testInput);

            Assert.Equal(output, result);
        }

        void P2_WithTestData_ShouldReturnCorrectValue()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _day.Puzzle2(testInput);
            
            Assert.Equal("", result);
        }
    }
}