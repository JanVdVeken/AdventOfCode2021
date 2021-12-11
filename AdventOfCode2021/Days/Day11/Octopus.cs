namespace Day11
{
    public class Octopus
    {
        public int X;
        public int Y;
        public int Value;
        public bool DidFlashthisStep;
        public Octopus(int i, int j, int value)
        {
            Y = i;
            X = j;
            Value = value;
        }

        public void IncreaseValue()
        {
            Value++;
        }
    }
}