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

        private IEnumerable<Position> GetPositionsUntilNotFree(IEnumerable<BoardStateInfo> boardStateInfos) 
        {
            var result = new List<Position>();
            foreach (var info in boardStateInfos)
            {
                if (info.State is null)
                {
                    result.Add(info.Position);
                }
                else if (info.State != Colour)
                {
                    result.Add(info.Position);
                    break;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public Position[] GetMoves(IGameBoard gameBoard, Position position)
        {
            var northPositions = gameBoard.GetBoardStateInfoInDirection(Direction.North, position);
            var eastPositions = gameBoard.GetBoardStateInfoInDirection(Direction.East, position);
            var southPositions = gameBoard.GetBoardStateInfoInDirection(Direction.South, position);
            var westPositions = gameBoard.GetBoardStateInfoInDirection(Direction.West, position);

            return GetPositionsUntilNotFree(northPositions)
                .Concat(GetPositionsUntilNotFree(eastPositions))
                .Concat(GetPositionsUntilNotFree(southPositions))
                .Concat(GetPositionsUntilNotFree(westPositions))
                .ToArray();
        }
    }
}
