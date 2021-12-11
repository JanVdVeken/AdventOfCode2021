using System.IO;
using System.Linq;
using Day11;
using Xunit;

namespace DaysTest
{
    public class Day11Test
    {
        private readonly Day11.Day11 _day;
        private readonly string _testInputLocation;

        public Day11Test()
        {
            _day = new ();
            _testInputLocation =
                @"../../../../../AdventOfCode2021.Test/AdventOfCode2021.Tests/TestInputs/D11.txt";
        }

        [Fact]
        void GetNeighbours_WithMiddleOctopus_returns8Neighbours()
        {
            var testInput = File.ReadLines(_testInputLocation);
            var cave = new OctopusGrid(testInput.ToList());
            var octopus = new Octopus(5, 5, 5);

            var result = cave.GetNeighbours(octopus).Count;

            Assert.Equal(8,result);
        }
        [Fact]
        void GetNeighbours_WithSideOctopus_returns5Neighbours()
        {
            var testInput = File.ReadLines(_testInputLocation);
            var cave = new OctopusGrid(testInput.ToList());
            var octopus = new Octopus(0, 5, 5);

            var result = cave.GetNeighbours(octopus).Count;

            Assert.Equal(5,result);
        }
        [Fact]
        void GetNeighbours_WithCornerOctopus_returns3Neighbours()
        {
            var testInput = File.ReadLines(_testInputLocation);
            var cave = new OctopusGrid(testInput.ToList());
            var octopus = new Octopus(0, 0, 5);

            var result = cave.GetNeighbours(octopus).Count;

            Assert.Equal(3,result);
        }
        [Fact]
        void P1_WithTestData_ShouldReturnCorrectValue()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _day.Puzzle1(testInput);

            Assert.Equal("1656", result);
        }

        [Fact]
        void Gridsize_WithTestData_ShouldBe100()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var cave = new OctopusGrid(testInput.ToList());
            
            Assert.Equal(100, cave.GridSize);
        }

        [Fact]
        void ModelLevels_WithTenStepsAndTestData_ShouldHave204Flashes()
        {
            var testInput = File.ReadLines(_testInputLocation);
            var cave = new OctopusGrid(testInput.ToList());
            
            cave.CalculateFlashes(10);
            
            Assert.Equal(204,cave.Flashes);
        }

        void P2_WithTestData_ShouldReturnCorrectValue()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _day.Puzzle2(testInput);
            
            Assert.Equal("", result);
        }
    }
}