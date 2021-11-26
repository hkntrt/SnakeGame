using System;

namespace SnakeGame
{
    struct Coordinate
    {
        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }

        public void DisplayCoordinate()
        {
            Console.WriteLine($"X: {X} - Y: {Y} ");
        }
        public static bool operator ==(Coordinate left, Coordinate right)
        {
            if (left.X == right.X && left.Y == right.Y)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Coordinate left, Coordinate right)
        {
            if (left.X != right.X || left.Y != right.Y)
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            if (this.X == ((Coordinate)obj).X && this.Y == ((Coordinate)obj).Y)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() * 17 + Y.GetHashCode();
        }
    }
}
