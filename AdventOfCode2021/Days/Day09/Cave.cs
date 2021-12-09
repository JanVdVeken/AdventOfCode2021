using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;

namespace Day09
{
    public class Cave
    {
        private Point[,] CaveOverview;
        private int _width;
        private int _depth;

        public Cave(List<string> input)
        {
            _depth = input.First().Length;
            _width = input.Count;
            CaveOverview = new Point[_width, _depth];
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _depth; j++)
                {
                    CaveOverview[i, j] = new Point()
                    {
                        Value = int.Parse(input[i].Substring(j, 1)),
                        IslowestInArea = false
                    };
                }
            }
        }

        public void CalculateLowestPoints()
        {
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _depth; j++)
                {
                    CaveOverview[i, j].IslowestInArea = CalculateIsLowestNeighbour(i,j);
                }
            }
        }

        private bool CalculateIsLowestNeighbour(int i,int j)
        {
            if (i == 0 | j == 0 | i == _width - 1 | j == _depth - 1) return CalculateLowestEdgeNeighbour(i,j);
            if(CaveOverview[i,j].Value >= CaveOverview[i+1,j].Value) return false;
            if(CaveOverview[i,j].Value >= CaveOverview[i-1,j].Value) return false;
            if(CaveOverview[i,j].Value >= CaveOverview[i,j+1].Value) return false;
            if(CaveOverview[i,j].Value >= CaveOverview[i,j-1].Value) return false;
            return true;
            
        }

        private bool CalculateLowestEdgeNeighbour(int i,int j)
        {
            if (i == 0 & j == 0)
            {
                if(CaveOverview[i,j].Value >= CaveOverview[i+1,j].Value) return false;
                if(CaveOverview[i,j].Value >= CaveOverview[i,j+1].Value) return false;
                return true;
            }
            if (i == 0 & j == _depth -1)
            {
                if(CaveOverview[i,j].Value >= CaveOverview[i+1,j].Value) return false;
                if(CaveOverview[i,j].Value >= CaveOverview[i,j-1].Value) return false;
                return true;
            }
            if (i == _width-1 & j == 0)
            {
                if(CaveOverview[i,j].Value >= CaveOverview[i-1,j].Value) return false;
                if(CaveOverview[i,j].Value >= CaveOverview[i,j+1].Value) return false;
                return true;
            }

            if (i == _width - 1 & j == _depth - 1)
            {
                if (CaveOverview[i, j].Value >= CaveOverview[i - 1, j].Value) return false;
                if (CaveOverview[i, j].Value >= CaveOverview[i, j - 1].Value) return false;
                return true;
            }
        
            if (i == 0)
            {
                if(CaveOverview[i,j].Value >= CaveOverview[i+1,j].Value) return false;
                if(CaveOverview[i,j].Value >= CaveOverview[i,j+1].Value) return false;
                if(CaveOverview[i,j].Value >= CaveOverview[i,j-1].Value) return false;
                return true;
            }
            if (i == _width-1)
            {
                if(CaveOverview[i,j].Value >= CaveOverview[i-1,j].Value) return false;
                if(CaveOverview[i,j].Value >= CaveOverview[i,j+1].Value) return false;
                if(CaveOverview[i,j].Value >= CaveOverview[i,j-1].Value) return false;
                return true;
            }
            if (j == 0)
            {
                if(CaveOverview[i,j].Value >= CaveOverview[i+1,j].Value) return false;
                if(CaveOverview[i,j].Value >= CaveOverview[i-1,j].Value) return false;
                if(CaveOverview[i,j].Value >= CaveOverview[i,j+1].Value) return false;
                return true; 
            }
            if (j == _depth-1)
            {
                if(CaveOverview[i,j].Value >= CaveOverview[i+1,j].Value) return false;
                if(CaveOverview[i,j].Value >= CaveOverview[i-1,j].Value) return false;
                if(CaveOverview[i,j].Value >= CaveOverview[i,j-1].Value) return false;
                return true; 
            }
            return false;
        }

        public int SumOfLowestPoints()
        {
            int sum = 0;
            foreach (var point in CaveOverview)
            {
                sum += point.IslowestInArea ? point.Value + 1 : 0;
            }

            return sum;
        }
    }
}