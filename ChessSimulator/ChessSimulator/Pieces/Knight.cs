using ChessSimulator.Enums;
using System.Linq;

namespace ChessSimulator.Pieces
{
    public class Knight : IPiece
    {
        public string Name { get => PieceNames.Knight; }

        public Colour Colour { get; }

        public Knight(Colour colour)
        {
            Colour = colour;
        }

        // order of the moves clockwise
        // |8| |1| 
        //7| | | |2
        // | |K| | 
        //6| | | |3
        // |5| |4| 
        public Position[] GetMoves(IGameBoard gameBoard, Position position)
        {
            var positions = new Position[]
            {
                // 1
                new Position(position.X + 1, position.Y - 2),
                // 2
                new Position(position.X + 2, position.Y - 1),
                // 3
                new Position(position.X + 2, position.Y + 1),
                // 4
                new Position(position.X + 1, position.Y + 2),
                // 5
                new Position(position.X - 1, position.Y + 2),
                // 6
                new Position(position.X - 2, position.Y + 1),
                // 7
                new Position(position.X - 2, position.Y - 1),
                // 8
                new Position(position.X - 1, position.Y - 2),
            };

            return gameBoard
                .GetBoardStateInfo(positions)
                .Where(x => x.State is null || x.State != Colour)
                .Select(x => x.Position).ToArray();
        }
    }
}
