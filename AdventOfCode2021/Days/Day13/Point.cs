using System.Linq;

namespace Day13
{
    public class Point
    {
        public int X;
        public int Y;
        public Point(string inputstring)
        {
            var splitinput = inputstring.Split(",").ToList().Select(int.Parse).ToList();
            X = splitinput[0];
            Y = splitinput[1];
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}