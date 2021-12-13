using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Channels;

namespace Day13
{
    public class OrigamiPaper
    {
        public List<Fold> Folds;
        public List<Point> Points;
        public OrigamiPaper(List<string> input)
        {
            Points = new List<Point>();
            Folds = new List<Fold>();
            foreach (var inputstring in input.Where(x => !x.Equals(string.Empty)))
            {
                if (!inputstring.Contains("fold along"))
                {
                    Points.Add(new Point(inputstring));
                }
                else
                {
                    Folds.Add(new Fold(inputstring));
                }
            }
        }

        public void DoAllFolds()
        {
            Folds.ForEach(DoTheFold);
        }

        public int CountPointsAfterTheFirstFold()
        {
            var firstFold = Folds.First();
            DoTheFold(firstFold);
            return Points.Count();
        }

        public void DoTheFold(Fold fold)
        {
            var toDelete = new List<Point>();
            var toAdd = new List<Point>();
            if (fold.Axis == 'x')
            {
                foreach (var currentPoint in Points.Where(point => point.X> fold.Amount))
                {
                    int x = fold.Amount - (currentPoint.X - fold.Amount);
                    var newPoint = new Point(x,currentPoint.Y);
                    toDelete.Add(currentPoint);
                    if(Points.Any(point1 => point1.X==newPoint.X && point1.Y == newPoint.Y)) continue;
                    toAdd.Add(newPoint);
                }
            }
            else
            {
                foreach (var currentPoint in Points.Where(point => point.Y> fold.Amount))
                {
                    int y = fold.Amount - (currentPoint.Y - fold.Amount);
                    var newPoint = new Point(currentPoint.X,y);
                    toDelete.Add(currentPoint);
                    if(Points.Any(point1 => point1.X==newPoint.X && point1.Y == newPoint.Y)) continue;
                    toAdd.Add(newPoint);
                }
            }

            foreach (var point in toDelete)
            {
                Points.RemoveAt(Points.FindIndex(x => x.X==point.X && x.Y==point.Y));
            }
            foreach (var point in toAdd)
            {
                
                Points.Add(point);
            }
        }

        public void PrintToConsole()
        {
            // Console.WriteLine(Points.Max(x =>x.X));
            // Console.WriteLine(Points.Max(x =>x.Y));
            int maxX = 40;
            int maxY= 6;
            char[,] printArray = new char[maxX, maxY];
            Points.ForEach(point => printArray[point.X,point.Y] = 'X');
            for (int i = 0; i < maxY; i++)
            {
                for (int j = 0; j < maxX; j++)
                {
                    Console.Write(printArray[j,i]);
                }
                Console.WriteLine();
            }
            
        }
    }
}