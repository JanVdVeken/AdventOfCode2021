namespace Day08
{
    public class Segment
    {
        public char Connection;
        public bool Active;

        public Segment(char connection, bool active)
        {
            Connection = connection;
            Active = active;
        }
    }
}