    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
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

            [Fact]
            private void P1_WithOneLineOfDate_ShouldReturnCorrectValue()
            {
                var test = new List<string>(){"gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce"};

                var result = _day.Puzzle1(test);
                
                Assert.Equal("2",result);
            }
            [Fact]
            private void SevenSegmentDisplayCtor_WithOneInput_ShouldOrderInputs()
            {
                var sevenSegment = new SevenSegmentDisplay("gcafb | fgae cfgab fg bagce");

                var result = sevenSegment.Inputs.First();
                
                Assert.Equal("abcfg",result);
            }
            [Fact]
            private void SevenSegmentDisplayCtor_WithMultipleInputs_ShouldOrderInputs()
            {
                var expected = new List<string>(){"abcfg","abcdefg"};
                var sevenSegment = new SevenSegmentDisplay("gcafb cfbegad | fgae cfgab fg bagce");

                var result = sevenSegment.Inputs;
                
                Assert.Equal(expected,result);
            }
            [Fact]
            private void SevenSegmentDisplayCtor_WithMultipleOutputs_ShouldOrderOutputs()
            {
                var expected = new List<string>(){"abcfg","fg"};
                var sevenSegment = new SevenSegmentDisplay("gcafb cfbegad | cfgab fg");

                var result = sevenSegment.Outputs;
                
                Assert.Equal(expected,result);
            }

            [Fact]
            private void SevenSegmentDisplay_WithInputs_ShouldOutputCorrectData()
            {
                var sevenSegment = new SevenSegmentDisplay("ab cagedb eafb cdfgeb cefabd dab acedgfb | ba cdfgeb");
                sevenSegment.CalculateConnections();

                var result = sevenSegment.GetValueOfOutput();
                
                Assert.Equal(16,result);
            }
            [Fact]
            void P1_WithTestData_ShouldReturnCorrectValue()
            {
                var testInput = File.ReadLines(_testInputLocation);
                
                var result = _day.Puzzle1(testInput);
                
                Assert.Equal("26", result);
            }
            [Fact]
            private void SevenSegmentDisplay_WithOneTestInput_ShouldOutputCorrectData()
            {
                var sevenSegment = new SevenSegmentDisplay("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf");
                sevenSegment.CalculateConnections();

                var result = sevenSegment.GetValueOfOutput();
                
                Assert.Equal(5353,result);
            }
            
            [Fact]
            void P2_WithTestData_ShouldReturnCorrectValue()
            {
                var testInput = File.ReadLines(_testInputLocation);
                
                var result = _day.Puzzle2(testInput);
                
                Assert.Equal("61229", result);
            }

            [Theory]
            [InlineData("be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",8394)]
            [InlineData("edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",9781)]
            [InlineData("fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",1197)]
            [InlineData("fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",9361)]
            [InlineData("aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",4873)]
            void SevenSegmentDisplay_TestOneByOne_ShouldReturnCorrectValue(string input, int output)
            {
                var sevSegDisp = new SevenSegmentDisplay(input);
                
                sevSegDisp.CalculateConnections();
                
                Assert.Equal(output, sevSegDisp.GetValueOfOutput());
            }
        }
    }