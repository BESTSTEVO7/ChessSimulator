using System;

namespace ChessSimulator.Exceptions
{
    public class NotOnBoardException : Exception
    {
        public NotOnBoardException(string? message) : base(message)
        {
        }
    }
}
