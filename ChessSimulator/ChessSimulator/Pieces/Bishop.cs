using ChessSimulator.Enums;
using ChessSimulator.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace ChessSimulator.Pieces
{
    public class Bishop : IPiece
    {
        public string Name { get => PieceNames.Bishop; }

        public Colour Colour { get; }

        public Bishop(Colour colour)
        {
            Colour = colour;
        }

        public Position[] GetMoves(IGameBoard gameBoard, Position position)
        {
            IList<Position> result = new List<Position>();
            var northEastPositions = gameBoard.GetBoardStateInfoInDirection(Direction.NorthEast, position);
            var northWestPositions = gameBoard.GetBoardStateInfoInDirection(Direction.NorthWest, position);
            var southEastPositions = gameBoard.GetBoardStateInfoInDirection(Direction.SouthEast, position);
            var southWestPositions = gameBoard.GetBoardStateInfoInDirection(Direction.SouthWest, position);

            return result.GetPositionsUntilNotFree(northEastPositions, Colour)
                .GetPositionsUntilNotFree(northWestPositions, Colour)
                .GetPositionsUntilNotFree(southEastPositions, Colour)
                .GetPositionsUntilNotFree(southWestPositions, Colour)
                .ToArray();
        }
    }
}
