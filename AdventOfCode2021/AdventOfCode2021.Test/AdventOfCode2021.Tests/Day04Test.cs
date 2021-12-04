using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Days;
using Xunit;

namespace Day04.Test
{
    public class Day04Test
    {
        private readonly Days.Day04 _do4;
        private readonly string _testInputLocation;
        
        public Day04Test()
        {
            _do4 = new Days.Day04();
            _testInputLocation =
                @"../../../../../AdventOfCode2021.Test/AdventOfCode2021.Tests/TestInputs/D04.txt";
        }

        [Fact]
        void CtorBingoForm_With25Numbers_Contains25Elements()
        {
            var input = new List<string>()
                    {"22 13 17 11  0",
                    " 8  2 23  4 24",
                    "21  9 14 16  7",
                    " 6 10  3 18  5",
                    " 1 12 20 15 19"};
            
            var form = new BingoForm(input);
            
            Assert.Equal(25,form.Form.Length);
        }

        [Fact]
        void CtorBingoController_WithTestDate_Creates3Froms()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            BingoController controller = new BingoController(testInput.ToList());

            Assert.Equal(3,controller.Forms.Count());
        }

        [Fact]
        void CheckWinningColumns_WithWinningDataInColumn_IsTrue()
        {
            var form = new BingoForm();
            
            form.Form = TestForms.WinningFormColumn;
            
            Assert.True(form.CheckWinningColumns());
        }
        [Fact]
        void CheckWinningColumns_WithoutWinningDataInColumn_IsFalse()
        {
            var form = new BingoForm();
            
            form.Form= TestForms.LosingForm;
            
            Assert.False(form.CheckWinningColumns());
        }
        
        [Fact]
        void CheckWinningRows_WithWinningDataInRow_IsTrue()
        {
            var form = new BingoForm();
             
            form.Form= TestForms.WinningFormRow;
            
            Assert.True(form.CheckWinningRow());
        }
        [Fact]
        void CheckWinningRows_WithoutWinningDataInRow_IsFalse()
        {
            var form = new BingoForm();
             
            form.Form=TestForms.LosingForm;
            
            Assert.False(form.CheckWinningRow());
        }

        [Fact]
        void CheckWinningForm_WithoutWinningData_IsFalse()
        {
            var form = new BingoForm();
            
            form.Form=TestForms.LosingForm;
            
            Assert.False(form.CheckIfFormIsCompletedRowsColumns());
        }
        
        [Fact]
        void P1_WithTestData_Returns4512()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _do4.Puzzle1(testInput);
            
            Assert.Equal("4512", result);
        }
        [Fact]
        void P2_WithTestData_Returns1924()
        {
            var testInput = File.ReadLines(_testInputLocation);
            
            var result = _do4.Puzzle2(testInput);
            
            Assert.Equal("1924", result);
        }
    }
    public static class TestForms
    {
        public static FormCell[,] WinningFormColumn = new FormCell[5, 5]
        {
            {new FormCell(0,true),new FormCell(0,false),new FormCell(0,false),new FormCell(0,false),new FormCell(0,false)},
            {new FormCell(0,true),new FormCell(0,false),new FormCell(0,false),new FormCell(0,false),new FormCell(0,false)},
            {new FormCell(0,true),new FormCell(0,false),new FormCell(0,false),new FormCell(0,false),new FormCell(0,false)},
            {new FormCell(0,true),new FormCell(0,false),new FormCell(0,false),new FormCell(0,false),new FormCell(0,false)},
            {new FormCell(0,true),new FormCell(0,false),new FormCell(0,false),new FormCell(0,false),new FormCell(0,false)}
        };
        public static FormCell[,] WinningFormRow = new FormCell[5, 5]
        {
            {new FormCell(0,true),new FormCell(0,true),new FormCell(0,true),new FormCell(0,true),new FormCell(0,true)},
            {new FormCell(0,false),new FormCell(0,false),new FormCell(0,false),new FormCell(0,false),new FormCell(0,false)},
            {new FormCell(0,false),new FormCell(0,false),new FormCell(0,false),new FormCell(0,false),new FormCell(0,false)},
            {new FormCell(0,false),new FormCell(0,false),new FormCell(0,false),new FormCell(0,false),new FormCell(0,false)},
            {new FormCell(0,false),new FormCell(0,false),new FormCell(0,false),new FormCell(0,false),new FormCell(0,false)}
        };
        public static FormCell[,] LosingForm = new FormCell[5, 5]
        {
            {new FormCell(0,true),new FormCell(0,false),new FormCell(0,false),new FormCell(0,false),new FormCell(0,false)},
            {new FormCell(0,false),new FormCell(0,true),new FormCell(0,false),new FormCell(0,false),new FormCell(0,false)},
            {new FormCell(0,false),new FormCell(0,false),new FormCell(0,true),new FormCell(0,false),new FormCell(0,false)},
            {new FormCell(0,false),new FormCell(0,false),new FormCell(0,false),new FormCell(0,true),new FormCell(0,false)},
            {new FormCell(0,false),new FormCell(0,false),new FormCell(0,false),new FormCell(0,false),new FormCell(0,true)}
        };
        
    }
}