using System;
using System.Collections.Generic;
using System.Linq;

namespace Day12
{
    public class Point
    {
        public string Value;
        public List<Point> Connections;

        public Point(string value)
        {
            Connections = new List<Point>();
            Value = value;
        }

        public void AddToConnections(Point point)
        {
            if(Connections.Any(x => x.Value == point.Value)) return;
            Connections.Add(point);
        }
    }
}