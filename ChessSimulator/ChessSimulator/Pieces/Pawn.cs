using System.Collections.Generic;

namespace ChessSimulator.Pieces
{
    public class Pawn : IPiece, IMoveInfo
    {
        private readonly Direction direction;

        private bool HasMoved;

        public string Name { get => PieceNames.Pawn; }

        public Colour Colour { get; }

        public Pawn(Colour colour, Direction direction)
        {
            Colour = colour;
            this.direction = direction;
        }

        private static bool IsFieldInFrontFree(BoardStateInfo? boardStateInfo)
        {
            return boardStateInfo is not null && boardStateInfo.State is null;
        }

        public Position[] GetMoves(IGameBoard gameBoard, Position position)
        {
            var result = new List<Position>();

            var aheadState = direction == Direction.North
                ? gameBoard.GetBoardStateInfo(new Position(position.X, position.Y - 1))
                : gameBoard.GetBoardStateInfo(new Position(position.X, position.Y + 1));

            var diagonalStates = direction == Direction.North
                ? gameBoard.GetBoardStateInfo(
                    new Position(position.X - 1, position.Y - 1), 
                    new Position(position.X + 1, position.Y - 1))
                : gameBoard.GetBoardStateInfo(
                    new Position(position.X - 1, position.Y + 1), 
                    new Position(position.X + 1, position.Y + 1));

            if (IsFieldInFrontFree(aheadState))
            {
                result.Add(aheadState!.Position);

                // The first move on a pawn can be two steps forwards.
                if (!HasMoved)
                {
                    var farAheadState = direction == Direction.North
                    ? gameBoard.GetBoardStateInfo(new Position(position.X, position.Y - 2))
                    : gameBoard.GetBoardStateInfo(new Position(position.X, position.Y + 2));

                    if (IsFieldInFrontFree(farAheadState))
                    {
                        result.Add(farAheadState!.Position);
                    }
                }
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

        public void Move()
        {
            HasMoved = true;
        }
    }
}
