using System.IO;
using Day13;
using Xunit;

namespace DaysTest
{
    public class Day13Test
    {
        private readonly Day13.Day13 _day;
        private readonly string _testInputLocation;

        public Day13Test()
        {
            _day = new Day13.Day13();
            _testInputLocation =
                @"../../../../../AdventOfCode2021.Test/AdventOfCode2021.Tests/TestInputs/D13.txt";
        }

        [Fact]
        void FoldCtor_WithCorrectData_ShouldGetCorrectValueAndAmount()
        {
            var fold = new Fold("fold along y=7");
            
            Assert.Equal('y',fold.Axis);
            Assert.Equal(7, fold.Amount);
        }

        [Fact]
        void PointCtor_WithCorrectData_ShouldGetCorrectXAndY()
        {
            var point = new Point("4,1");
            
            Assert.Equal(4,point.X);
            Assert.Equal(1, point.Y);
        }
        
        [Fact]
        void P1_WithTestData_ShouldReturnCorrectValue()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _day.Puzzle1(testInput);
            
            Assert.Equal("17", result);
        }

        void P2_WithTestData_ShouldReturnCorrectValue()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _day.Puzzle2(testInput);
            
            Assert.Equal("", result);
        }
    }
}