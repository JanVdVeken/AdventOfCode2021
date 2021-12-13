using System.Collections.Generic;
using System.Data;
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
                AddConnectionBetweenPoints(p1,p2);
            }
        }

        public void CalculateAllPathsWithoutDoubleLowerCasesWithStartingPoint()
        {
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
            var currentPath = path +'|' + point.Value;
            foreach (var connection in point.Connections)
            {
                CalculateAllPathsWithoutDoubleLowerCases(connection,currentPath);
            }
        }
        public void CalculateAllPathsWithOneDoubleLowerCaseWithStartingPoint()
        {
            CalculateAllPathsWithOneDoubleLowerCase(AllPoints.First(x => x.Value.Equals("start")),"");
        }
        public void CalculateAllPathsWithOneDoubleLowerCase(Point point,string path)
        {
            if(ContainsMoreThenOneDoubleLowerCasePoint(path)) return;
            if (point.Value.Equals("end"))
            {
                Count++;
                return;
            }
            var currentPath = path +'|' + point.Value;
            foreach (var connection in point.Connections.Where(x => !x.Value.Equals("start")))
            {
                CalculateAllPathsWithOneDoubleLowerCase(connection,currentPath);
            }
        }

        public bool ContainsMoreThenOneDoubleLowerCasePoint(string input)
        {
            var allPossibleSmallCaves = AllPoints.Where(point => point.Value.All(char.IsLower)).Select(x => x.Value);
            var currentTracker = 0;
            foreach (var currentValue in allPossibleSmallCaves)
            {
                var temp = input.Replace(currentValue, "!");
                if (temp.Count(x => x == '!') == 2) currentTracker++;
                if (temp.Count(x => x == '!') > 2) return true;
            }
            return currentTracker >= 2;
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