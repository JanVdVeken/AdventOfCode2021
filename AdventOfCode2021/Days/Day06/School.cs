using System.Collections.Generic;
using System.Linq;

namespace Days
{
    public class School
    {
        private List<LanternFish> lanternfish;

        public School()
        {
            lanternfish = new List<LanternFish>();
        }
        
        public School(List<int> inputs)
        {
            lanternfish = new List<LanternFish>();
            inputs.ForEach(x => lanternfish.Add(new LanternFish(x)));
        }
        
        public int GetSchoolSize()
        {
            return lanternfish.Count();
        }

        public void SimulateDays(int days)
        {
            for (int i = 0; i < days; i++)
            {
                int count = 0;
                lanternfish.ForEach(x => count += x.AgeOneDay());
                for (int j = 0; j < count; j++)
                {
                    lanternfish.Add(new LanternFish(8));
                }
            }
        }
    }
}