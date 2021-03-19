﻿namespace ChessSimulator
{
    public struct Position
    {
        public int X { get; set; }

        public int Y { get; set; }

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
            return firstPosition.X == secondPosition.X && firstPosition.Y == secondPosition.Y;
        }

        public static bool operator !=(Position firstPosition, Position secondPosition)
        {
            return firstPosition.X != secondPosition.X || firstPosition.Y != secondPosition.Y;
        }
    }
}