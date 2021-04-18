using ChessSimulator.Enums;
using ChessSimulator.Pieces;

namespace ChessSimulator.Extensions
{
    internal static class DefaultGameBoardExtensions
    {
        internal static IPiece[,] GenerateNewBoard() 
        {
            var pieces = new IPiece[8, 8];
            pieces[0, 0] = new Rook(Colour.Black);
            pieces[1, 0] = new Knight(Colour.Black);
            pieces[2, 0] = new Bishop(Colour.Black);
            pieces[3, 0] = new Queen(Colour.Black);
            pieces[4, 0] = new King(Colour.Black);
            pieces[5, 0] = new Bishop(Colour.Black);
            pieces[6, 0] = new Knight(Colour.Black);
            pieces[7, 0] = new Rook(Colour.Black);

            pieces[0, 1] = new Pawn(Colour.Black, Direction.East);
            pieces[1, 1] = new Pawn(Colour.Black, Direction.East);
            pieces[2, 1] = new Pawn(Colour.Black, Direction.East);
            pieces[3, 1] = new Pawn(Colour.Black, Direction.East);
            pieces[4, 1] = new Pawn(Colour.Black, Direction.East);
            pieces[5, 1] = new Pawn(Colour.Black, Direction.East);
            pieces[6, 1] = new Pawn(Colour.Black, Direction.East);
            pieces[7, 1] = new Pawn(Colour.Black, Direction.East);

            pieces[0, 7] = new Rook(Colour.White);
            pieces[1, 7] = new Knight(Colour.White);
            pieces[2, 7] = new Bishop(Colour.White);
            pieces[3, 7] = new Queen(Colour.White);
            pieces[4, 7] = new King(Colour.White);
            pieces[5, 7] = new Bishop(Colour.White);
            pieces[6, 7] = new Knight(Colour.White);
            pieces[7, 7] = new Rook(Colour.White);

            pieces[0, 6] = new Pawn(Colour.White, Direction.North);
            pieces[1, 6] = new Pawn(Colour.White, Direction.North);
            pieces[2, 6] = new Pawn(Colour.White, Direction.North);
            pieces[3, 6] = new Pawn(Colour.White, Direction.North);
            pieces[4, 6] = new Pawn(Colour.White, Direction.North);
            pieces[5, 6] = new Pawn(Colour.White, Direction.North);
            pieces[6, 6] = new Pawn(Colour.White, Direction.North);
            pieces[7, 6] = new Pawn(Colour.White, Direction.North);

            return pieces;
        }
    }
}
