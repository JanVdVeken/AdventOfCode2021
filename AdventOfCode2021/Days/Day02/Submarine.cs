namespace Days
{
    public class Submarine
    {
        public int PositionDepth;
        public int PositionHorizontal;
        public int Aim;

        public Submarine(int positionDepth, int positionHorizontal)
        {
            PositionDepth = positionDepth;
            PositionHorizontal = positionHorizontal;
        }

        public int CalcPosition()
        {
            return PositionDepth * PositionHorizontal;
        }

        public void Move(Command command)
        {
            switch(command.Direction)
            {
                case "forward":
                    PositionHorizontal += command.Amount;
                    break;
                case "down":
                    PositionDepth += command.Amount;
                    break;
                case "up":
                    PositionDepth -= command.Amount;
                    break;
            }
        }

        public void ReAim(Command command)
        {
            switch(command.Direction)
            {
                case "forward":
                    PositionHorizontal += command.Amount;
                    PositionDepth += Aim * command.Amount;
                    break;
                case "down":
                    Aim += command.Amount;
                    break;
                case "up":
                    Aim -= command.Amount;
                    break;
            }
        }
        
    }
}