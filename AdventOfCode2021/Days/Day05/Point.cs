using System.Collections.Generic;

namespace Days
{
    public class Point
    {
        public int X;
        public int Y;

        public Point(string input)
        {
            X = int.Parse(input.Split(",")[0]);
            Y = int.Parse(input.Split(",")[1]);
        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class PointEqualityComparer : IEqualityComparer<Point>
    {
        public bool Equals(Point? point1, Point? point2)
        {
            return point1.X == point2.X & point1.Y == point2.Y;
        }

        public int GetHashCode(Point obj)
        {
            return $"{obj.X}{obj.Y}".GetHashCode();
        }
    }
    
}