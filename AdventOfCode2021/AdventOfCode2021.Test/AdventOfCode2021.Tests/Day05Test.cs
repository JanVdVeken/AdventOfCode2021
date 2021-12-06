using System.IO;
using System.Linq;
using System.Reflection;
using Days;
using Xunit;

namespace DaysTest
{
    public class Day05Test
    {
        private readonly Day05 _do5;
        private readonly string _testInputLocation;
        
        public Day05Test()
        {
            _do5 = new Day05();
            _testInputLocation =
                @"../../../../../AdventOfCode2021.Test/AdventOfCode2021.Tests/TestInputs/D05.txt";
        }

        [Fact]
        void LineIsVerticalOrHorizontal_WithHorizontalPoints_ShouldReturnTrue()
        {
            var startPoint = new Point(1, 10);
            var endPoint = new Point(5, 10);

            var line = new Line(startPoint, endPoint);
            
            Assert.True(line.IsVerticalOrHorizontal());
        }
        [Fact]
        void CtorPoint_WithOneLineOfInputData()
        {
            var point = new Point("0,9");
            
            Assert.Equal(0,point.X);
            Assert.Equal(9,point.Y);
        }
        [Fact]
        void CtorLine_WithOneLineOfInputData()
        {
            var line = new Line("0,9 -> 5,9");
            
            Assert.Equal(0,line.StartPoint.X);
            Assert.Equal(9,line.StartPoint.Y);
            Assert.Equal(5,line.EndPoint.X);
            Assert.Equal(9,line.EndPoint.Y);
        }

        [Theory]
        [InlineData("0,9 -> 5,9",6)]
        [InlineData("5,9 -> 0,9",6)]
        [InlineData("5,9 -> 5,9",1)]
        [InlineData("5,1 -> 5,9",9)]
        [InlineData("5,9 -> 5,1",9)]
        void HorizontalOrVerticalLine_ShouldContainPoints(string input, int expected)
        {
            var line = new Line(input);

            var result = line.ReturnAllPointsOnLine();
            
            Assert.Equal(expected,result.Count());
        }
        
        [Theory]
        [InlineData("0,0 -> 1,1",2)]
        [InlineData("1,1 -> 0,0",2)]
        [InlineData("0,0 -> 9,9",10)]
        [InlineData("2,2 -> 9,9",8)]
        [InlineData("3,5 -> 5,7",3)]
        [InlineData("5,7 -> 3,5",3)]
        [InlineData("9,7 -> 7,9",3)]
        void DiagonalLine_ShouldContainPoints(string input, int expected)
        {
            var line = new Line(input);

            var result = line.ReturnAllPointsOnLine();
            
            Assert.Equal(expected,result.Count());
        }
        [Fact]
        void P1_WithTestData_Returns5()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _do5.Puzzle1(testInput);
            
            Assert.Equal("5", result);
        }
        [Fact]
        void P2_WithTestData_Returns12()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _do5.Puzzle2(testInput);
            
            Assert.Equal("12", result);
        }
    }
}