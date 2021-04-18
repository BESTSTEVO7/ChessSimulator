using ChessSimulator.Enums;
using ChessSimulator.Extensions;
using ChessSimulator.Gameboards;
using System.Collections.Generic;
using System.Linq;

namespace ChessSimulator.Pieces
{
    public class Queen : IPiece
    {
        public string Name { get => PieceNames.Queen; }

        public Colour Colour { get; }

        public Queen(Colour colour)
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

            var northEastPositions = gameBoard.GetBoardStateInfoInDirection(Direction.NorthEast, position);
            var northWestPositions = gameBoard.GetBoardStateInfoInDirection(Direction.NorthWest, position);
            var southEastPositions = gameBoard.GetBoardStateInfoInDirection(Direction.SouthEast, position);
            var southWestPositions = gameBoard.GetBoardStateInfoInDirection(Direction.SouthWest, position);

            return result.GetPositionsUntilNotFree(northPositions, Colour)
                .GetPositionsUntilNotFree(eastPositions, Colour)
                .GetPositionsUntilNotFree(southPositions, Colour)
                .GetPositionsUntilNotFree(westPositions, Colour)
                .GetPositionsUntilNotFree(northEastPositions, Colour)
                .GetPositionsUntilNotFree(northWestPositions, Colour)
                .GetPositionsUntilNotFree(southEastPositions, Colour)
                .GetPositionsUntilNotFree(southWestPositions, Colour)
                .ToArray();
        }
    }
}
