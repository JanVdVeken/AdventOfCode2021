using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Day09
{
    public class Cave
    {
        private Point[,] CaveOverview;
        private int _width;
        private int _depth;

        private List<Point> _points;
        private List<List<Point>> _basins;

        public Cave(List<string> input)
        {
            _basins = new List<List<Point>>();
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
            _points = new List<Point>();
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _depth; j++)
                {
                    CaveOverview[i, j].IslowestInArea = CalculateIsLowestNeighbour(i,j);
                    _points.Add(new Point()
                        {
                            X = i,
                            Y = j,
                            IslowestInArea = CaveOverview[i, j].IslowestInArea,
                            Value = CaveOverview[i, j].Value,
                            IsVisited = false
                        });
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

        public void CalculateBasins()
        {
            CalculateLowestPoints();
            foreach (var lowestPoint in _points.Where(x => x.IslowestInArea))
            {
                if (_basins.Any(x => x.Contains(lowestPoint))) continue;
                var points = new List<Point>(_points);
                var currentBasin = CalculateBasinFromPoint(lowestPoint,points);
                _basins.Add(currentBasin.DistinctBy(x => (1000 *x.X) + x.Y).ToList());
            }
        }

        private List<Point> CalculateBasinFromPoint(Point point,List<Point> points)
        {
            
            var possibleNeighbours = CalculatePossibleNeighbours(point, points);
            if (!possibleNeighbours.Any()) return new List<Point>(){point};
            point.IsVisited = true;
            var returnList = new List<Point>(){point};
            foreach (var newPoint in possibleNeighbours)
            {
                CalculateBasinFromPoint(newPoint, points).ForEach(x => returnList.Add(x));
            }
            return returnList;
        }

        public List<Point> CalculatePossibleNeighbours(Point point, List<Point> points)
        {
            var neighbours = new List<Point>();
            if(points.Any(x => x.X == point.X+1 & x.Y == point.Y & !x.IsVisited & x.Value != 9)) neighbours.Add(points.FirstOrDefault(x => x.X == point.X+1 & x.Y == point.Y & !x.IsVisited & x.Value != 9));
            if(points.Any(x => x.X == point.X-1 & x.Y == point.Y & !x.IsVisited & x.Value != 9)) neighbours.Add(points.FirstOrDefault(x => x.X == point.X-1 & x.Y == point.Y & !x.IsVisited & x.Value != 9));
            if(points.Any(x => x.X == point.X & x.Y == point.Y+1 & !x.IsVisited & x.Value != 9)) neighbours.Add(points.FirstOrDefault(x => x.X == point.X & x.Y == point.Y+1 & !x.IsVisited & x.Value != 9));
            if(points.Any(x => x.X == point.X & x.Y == point.Y-1 & !x.IsVisited & x.Value != 9)) neighbours.Add(points.FirstOrDefault(x => x.X == point.X & x.Y == point.Y-1 & !x.IsVisited & x.Value != 9));
            return neighbours;
        }

        public int ProductOfCountThreeBiggestBasins()
        {
            var orderdBasins = _basins.OrderByDescending(x => x.Count).ToList();
            return orderdBasins[0].Count * orderdBasins[1].Count * orderdBasins[2].Count;
        }

        public int GetBasinsCount()
        {
            return _basins.Count();
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