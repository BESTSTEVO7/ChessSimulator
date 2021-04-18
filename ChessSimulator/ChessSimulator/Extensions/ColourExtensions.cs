using ChessSimulator.Enums;
using System;

namespace ChessSimulator.Extensions
{
    public static class ColourExtensions
    {
        public static Colour GetEnemy(this Colour colour) 
        {
            switch (colour) 
            {
                case Colour.White:
                    return Colour.Black;
                case Colour.Black:
                    return Colour.White;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
