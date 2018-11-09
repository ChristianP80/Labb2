using System;
namespace Labb2
{
    public class Position
    {
        private int x;
        private int y;

        public int X
        {
            get { return x; }
            set
            {
                x = (value >= 0) ? value : 0;
                //if (value >= 0)
                //    x = value;

                //x = 0;
            }
        }

        public int Y
        {
            get { return y; }
            set
            {
                y = (value >= 0) ? value : 0 ;
                //if (value >= 0)
                //    y = value;

                //y = 0;
            }
        }
 

        public Position(int xCoord, int yCoord)
        {
            X = xCoord;
            Y = yCoord;
        }

        public double Length(int xCoord, int yCoord)
        {
            return Math.Sqrt(xCoord * xCoord + yCoord * yCoord);
        }

        public bool Equals(Position p)
        {
            return p.X == X && p.Y == Y;
        }
    }
}
