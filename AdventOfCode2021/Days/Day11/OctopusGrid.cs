using System.Collections.Generic;
using System.Linq;

namespace Day11
{
    public class OctopusGrid
    {
        private List<Octopus> _grid;
        public int Flashes;
        public int GridSize => _grid.Count();
        public OctopusGrid(List<string> inputList)
        {
            _grid = new List<Octopus>();
            var width = inputList.First().Length;
            var depth = inputList.Count;
            for (int i = 0; i < depth; i++)
            {
                var currentLine = inputList[i]; 
                for (int j = 0; j < width; j++)
                {
                    _grid.Add(new Octopus(i,j,int.Parse(currentLine.Substring(j,1))));
                }
            }
        }

        public List<Octopus> GetNeighbours(Octopus octopus)
        {
            return _grid.Where(x => (x.X == octopus.X+1 && x.Y == octopus.Y)
                                        || (x.X == octopus.X-1 && x.Y == octopus.Y)
                                        || (x.X == octopus.X && x.Y == octopus.Y+1)
                                        || (x.X == octopus.X && x.Y == octopus.Y-1)
                                        || (x.X == octopus.X+1 && x.Y == octopus.Y-1)
                                        || (x.X == octopus.X+1 && x.Y == octopus.Y+1)
                                        || (x.X == octopus.X-1 && x.Y == octopus.Y-1)
                                        || (x.X == octopus.X-1 && x.Y == octopus.Y+1)
                                        ).ToList();
        }

        public void CalculateFlashes(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                _grid.ForEach(x => x.IncreaseValue());
                
                while (_grid.Any(x => x.Value > 9 && !x.DidFlashthisStep))
                {
                    var currentOctopus = _grid.First(x => x.Value > 9 && !x.DidFlashthisStep);
                    currentOctopus.DidFlashthisStep = true;
                    GetNeighbours(currentOctopus).ForEach(x => x.IncreaseValue());
                }
                _grid.Where(x => x.DidFlashthisStep == true).ToList().ForEach(x => x.Value =0);
                Flashes += _grid.Count(x => x.DidFlashthisStep);
                _grid.ForEach(x => x.DidFlashthisStep = false);
            }
        }

        public int SynchronizedFlashing()
        {
            int i = 0;
            int amountOfFlashes =0;
            while (amountOfFlashes != 100)
            {
                _grid.ForEach(x => x.IncreaseValue());
                
                while (_grid.Any(x => x.Value > 9 && !x.DidFlashthisStep))
                {
                    var currentOctopus = _grid.First(x => x.Value > 9 && !x.DidFlashthisStep);
                    currentOctopus.DidFlashthisStep = true;
                    GetNeighbours(currentOctopus).ForEach(x => x.IncreaseValue());
                }
                _grid.Where(x => x.DidFlashthisStep == true).ToList().ForEach(x => x.Value =0);
                amountOfFlashes = _grid.Count(x => x.DidFlashthisStep);
                _grid.ForEach(x => x.DidFlashthisStep = false);
                i++;
            }

            return i;
        }
    }
}