namespace Day02
{
    public class Command
    {
        public string Direction;
        public int Amount;

        public Command(string direction, int amount)
        {
            Direction = direction;
            Amount = amount;
        }
    }
}