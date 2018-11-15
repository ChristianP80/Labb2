using System;
namespace Labb2
{
    public class Position
    {
        private double x;
        private double y;

        public double X
        {
            get { return x; }
            set { x = (value >= 0) ? value : 0; }
        }

        public double Y
        {
            get { return y; }
            set { y = (value >= 0) ? value : 0 ; }
        }

        public Position(double xCoord, double yCoord)
        {
            X = xCoord;
            Y = yCoord;
        }

        public double Length()
        {
            double xValue = Math.Pow(x, 2);
            double yValue = Math.Pow(y, 2);
            return Math.Sqrt(xValue + yValue);
        }

        public bool Equals(Position p)
        {
            return p.X == X && p.Y == Y;
        }

        public Position Clone()
        {
            return new Position(X, Y);
        }

        public override String ToString()
        {
            return "(" + X + ", " + Y + ")";
        }

        public static bool operator >(Position p1, Position p2)
        {
            return p1.Length().Equals(p2.Length()) ? p1.x > p2.x : p1.Length() > p2.Length();
        }

        public static bool operator <(Position p1, Position p2)
        {
            return p1.Length().Equals(p2.Length()) ? p1.x < p2.x : p1.Length() < p2.Length();
        }

        public static Position operator +(Position p1, Position p2)
        {
            return new Position(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Position operator -(Position p1, Position p2)
        {
            return new Position(p1.X- p2.X, p1.Y - p2.Y);
        }

        public static double operator %(Position p1, Position p2)
        {
            double xValue = Math.Pow(p1.X - p2.X, 2);
            double yValue = Math.Pow(p1.Y - p2.Y, 2);
            return Math.Sqrt(xValue + yValue);
        }
    }
}
