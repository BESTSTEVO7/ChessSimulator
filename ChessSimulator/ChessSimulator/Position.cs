using System;

namespace ChessSimulator
{
    public readonly struct Position : IEquatable<Position>
    {
        public int X { get; }

        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Position operator +(Position firstPosition, Position secondPosition) 
        {
            return new Position(firstPosition.X + secondPosition.X, firstPosition.Y + secondPosition.Y);
        }

        public static bool operator ==(Position firstPosition, Position secondPosition)
        {
            return firstPosition.Equals(secondPosition);
        }

        public static bool operator !=(Position firstPosition, Position secondPosition)
        {
            return !firstPosition.Equals(secondPosition);
        }

        public override bool Equals(object? obj)
        {
            return obj is not null && Equals((Position)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public bool Equals(Position other)
        {
            return this.X == other.X && this.Y == other.Y;
        }
    }
}