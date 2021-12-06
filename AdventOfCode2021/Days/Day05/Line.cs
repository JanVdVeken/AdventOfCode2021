using System.Collections.Generic;

namespace Days
{
    public class Line
    {
        public Point StartPoint;
        public Point EndPoint;
        public Line(Point endPoint, Point startPoint)
        {
            EndPoint = endPoint;
            StartPoint = startPoint;
        }

        public Line(string input)
        {
            var points = input.Split(" -> ");
            StartPoint = new Point(points[0]);
            EndPoint = new Point(points[1]);
        }

        public bool IsVerticalOrHorizontal()
        {
            return StartPoint.X == EndPoint.X | StartPoint.Y == EndPoint.Y;
        }

        public List<Point> ReturnAllPointsOnLine()
        {
            var pointsOnLine = new List<Point>();
            if (IsVerticalOrHorizontal())
            {
                if (StartPoint.X == EndPoint.X)
                {
                    if (StartPoint.Y > EndPoint.Y)
                    {
                        for (int y = EndPoint.Y; y <= StartPoint.Y; y++)
                        {
                            pointsOnLine.Add(new Point(StartPoint.X,y));
                        }
                    }
                    else
                    {
                        for (int y = StartPoint.Y; y <= EndPoint.Y; y++)
                        {
                            pointsOnLine.Add(new Point(StartPoint.X,y));
                        }
                    }
                }
                else
                {
                    if (StartPoint.X > EndPoint.X)
                    {
                        for (int x = EndPoint.X; x <= StartPoint.X; x++)
                        {
                            pointsOnLine.Add(new Point(x,StartPoint.Y));
                        }
                    }
                    else
                    {
                        for (int x = StartPoint.X; x <= EndPoint.X; x++)
                        {
                            pointsOnLine.Add(new Point(x,StartPoint.Y));
                        }
                    }
                }
            }
            else
            {
                if (StartPoint.X > EndPoint.X)
                {
                    if (StartPoint.Y > EndPoint.Y)
                    {
                        int y = EndPoint.Y;
                        for (int x = EndPoint.X; x <= StartPoint.X; x++)
                        {
                            pointsOnLine.Add(new Point(x,y));
                            y++;
                        }  
                    }
                    else
                    {
                        int y = EndPoint.Y;
                        for (int x = EndPoint.X; x <= StartPoint.X; x++)
                        {
                            pointsOnLine.Add(new Point(x,y));
                            y--;
                        } 
                    }

                }
                else
                {
                    if (StartPoint.Y > EndPoint.Y)
                    {
                        int y = StartPoint.Y;
                        for (int x = StartPoint.X; x <= EndPoint.X; x++)
                        {
                            pointsOnLine.Add(new Point(x,y));
                            y--;
                        }     
                    }
                    else
                    {
                        int y = StartPoint.Y;
                        for (int x = StartPoint.X; x <= EndPoint.X; x++)
                        {
                            pointsOnLine.Add(new Point(x,y));
                            y++;
                        }  
                    }
 
                }
            }
            return pointsOnLine;
        }

    }
}