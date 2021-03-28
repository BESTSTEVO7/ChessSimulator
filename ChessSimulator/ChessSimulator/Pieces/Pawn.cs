using System.Collections.Generic;

namespace ChessSimulator.Pieces
{
    public class Pawn : IPiece
    {
        private readonly Direction direction;

        public string Name { get => PieceNames.Pawn; }

        public Colour Colour { get; }

        public Pawn(Colour colour, Direction direction)
        {
            Colour = colour;
            this.direction = direction;
        }

        // TODO first move can be 2 fields
        public Position[] GetMoves(IGameBoard gameBoard, Position position)
        {
            var result = new List<Position>();

            // TODO for aheadState and diagonalState check if is Onboard, otherwise i check -1 coords for example
            var aheadState = direction == Direction.North
                ? gameBoard.GetBoardStateInfo(new Position(position.X, position.Y - 1))
                : gameBoard.GetBoardStateInfo(new Position(position.X, position.Y + 1));

            var diagonalStates = direction == Direction.North
                ? gameBoard.GetBoardStateInfo(new Position(position.X - 1, position.Y - 1), new Position(position.X + 1, position.Y - 1))
                : gameBoard.GetBoardStateInfo(new Position(position.X - 1, position.Y + 1), new Position(position.X + 1, position.Y + 1));

            if (aheadState is not null && aheadState.State is null)
            {
                result.Add(aheadState.Position);
            }

            foreach (var boardStateInfo in diagonalStates) 
            {
                if (boardStateInfo.State.HasValue && boardStateInfo.State.Value != Colour)
                {
                    result.Add(boardStateInfo.Position);
                }
            }

            return result.ToArray();
        }
    }
}
