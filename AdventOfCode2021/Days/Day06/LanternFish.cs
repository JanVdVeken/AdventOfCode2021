using System;

namespace Days
{
    public class LanternFish
    {
        public int DayForReproduce;

        public LanternFish(int dayForReproduce)
        {
            DayForReproduce = dayForReproduce;
        }

        public int AgeOneDay()
        {
            if (DayForReproduce == 0)
            {
                DayForReproduce = 6;
                return 1;
            }
            else
            {
                DayForReproduce--;
                return 0;
            }
        }
    }
}