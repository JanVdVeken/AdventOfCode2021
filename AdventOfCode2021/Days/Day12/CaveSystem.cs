using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Day12
{
    public class CaveSystem
    {
        public List<Point> AllPoints;
        public int Count;

        public CaveSystem(List<string> input)
        {
            AllPoints = new List<Point>();
            foreach (var inputstring in input)
            {
                var twoPoints = inputstring.Split("-");
                AddPointsToCaveSystem(twoPoints[0]);
                AddPointsToCaveSystem(twoPoints[1]);
                var p1 = AllPoints.First(x => x.Value == twoPoints[0]);
                var p2 = AllPoints.First(x => x.Value == twoPoints[1]);
                AddConnectionBetweenPoints(p1!,p2!);
            }

            CalculateAllPathsWithoutDoubleLowerCases(AllPoints.First(x => x.Value.Equals("start")),"");
        }

        public void CalculateAllPathsWithoutDoubleLowerCases(Point point,string path)
        {
            if (path.Contains(point.Value) && point.Value.All(char.IsLower)) return;
            if (point.Value.Equals("end"))
            {
                Count++;
                return;
            }
            var currentPath = path + point.Value;
            foreach (var connection in point.Connections)
            {
                CalculateAllPathsWithoutDoubleLowerCases(connection,currentPath);
            }
        }
        

        private void AddConnectionBetweenPoints(Point p1, Point p2)
        {
            p1.AddToConnections(p2);
            p2.AddToConnections(p1);
        }

        private void AddPointsToCaveSystem(string pointString)
        {
            if (AllPoints.Any(x => x.Value.Equals(pointString))) return;
            AllPoints.Add(new Point(pointString));
        }
    }
}