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

        public Position[] GetMoves(IGameBoard gameBoard, Position position)
        {
            var result = new List<Position>();
            var aheadState = direction == Direction.Forward
                ? gameBoard.GetBoardStateInfo(new Position(position.X - 1, position.Y))
                : gameBoard.GetBoardStateInfo(new Position(position.X + 1, position.Y));

            var diagonalStates = direction == Direction.Forward
                ? gameBoard.GetBoardStateInfo(new Position(position.X - 1, position.Y + 1), new Position(position.X + 1, position.Y + 1))
                : gameBoard.GetBoardStateInfo(new Position(position.X - 1, position.Y - 1), new Position(position.X + 1, position.Y - 1));

            if (aheadState.State is null)
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
