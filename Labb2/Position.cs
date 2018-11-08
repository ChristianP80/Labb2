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

        public Position()
        {
        }
    }
}
