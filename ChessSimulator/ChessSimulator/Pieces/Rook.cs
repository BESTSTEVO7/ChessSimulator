using ChessSimulator.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace ChessSimulator.Pieces
{
    public class Rook : IPiece
    {
        public string Name { get => PieceNames.Rook; }

        public Colour Colour { get; }

        public Rook(Colour colour)
        {
            Colour = colour;
        }

        public Position[] GetMoves(IGameBoard gameBoard, Position position)
        {
            IList<Position> result = new List<Position>();
            var northPositions = gameBoard.GetBoardStateInfoInDirection(Direction.North, position);
            var eastPositions = gameBoard.GetBoardStateInfoInDirection(Direction.East, position);
            var southPositions = gameBoard.GetBoardStateInfoInDirection(Direction.South, position);
            var westPositions = gameBoard.GetBoardStateInfoInDirection(Direction.West, position);

            return result.GetPositionsUntilNotFree(northPositions, Colour)
                .GetPositionsUntilNotFree(eastPositions, Colour)
                .GetPositionsUntilNotFree(southPositions, Colour)
                .GetPositionsUntilNotFree(westPositions, Colour)
                .ToArray();
        }
    }
}
