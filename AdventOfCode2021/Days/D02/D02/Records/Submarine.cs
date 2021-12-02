namespace D02.Records
{
    public class Submarine
    {
        public int PositionHorizontal;
        public int PositionDepth;

        public Submarine(int positionDepth, int positionHorizontal)
        {
            PositionDepth = positionDepth;
            PositionHorizontal = positionHorizontal;
        }
            
        public void Move(Command command)
        {
            switch (command.Direction)
            {
                case "up": PositionDepth -= command.Amount;
                    break;
                case "down": PositionDepth += command.Amount;
                    break;
                case "forward": PositionHorizontal += command.Amount;
                    break;
            }
        }

        public int CalcPosition()
        {
            return PositionDepth * PositionHorizontal;
        }
    }

}