using System.Collections.Generic;
using System.Linq;

namespace Day06
{
    public class School
    {
        private long[] _lanternfish;
        
        public School(List<int> inputs)
        {
            _lanternfish = new long[9];
            inputs.ForEach(x => _lanternfish[x] += 1);
        }

        public long[] GetArray()
        {
            return _lanternfish;
        }
        public long GetSchoolSize()
        {
            return _lanternfish.Sum();
        }

        public void SimulateDays(int days)
        {
            for (int i = 0; i < days; i++)
            {
                var tempArray = new long[9];
                for (int j = 0; j < _lanternfish.Count()-1; j++)
                {
                    tempArray[j] = _lanternfish[j + 1];
                }
                tempArray[8] = _lanternfish[0];
                tempArray[6] += _lanternfish[0];
                _lanternfish = tempArray;
            }
        }
    }
}