﻿namespace Days
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