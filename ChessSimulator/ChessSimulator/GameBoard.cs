using ChessSimulator.Exceptions;
using ChessSimulator.Pieces;
using System.Collections.Generic;
using System.Linq;

namespace ChessSimulator
{
    public class GameBoard : IGameBoard
    {
        private readonly IPiece?[,] board;

        private static readonly IReadOnlyDictionary<Direction, Position> directionDeltas =
            new Dictionary<Direction, Position>
            {
                // TODO
                [Direction.North] = new Position(0, -1),
                [Direction.East] = new Position(1, 0),
                [Direction.South] = new Position(0, 1),
                [Direction.West] = new Position(-1, 0),
                [Direction.NorthEast] = new Position(1, -1),
                [Direction.NorthWest] = new Position(-1, -1),
                [Direction.SouthEast] = new Position(1, 1),
                [Direction.SouthWest] = new Position(-1, 1),
            };

        public bool Move(Position from, Position to)
        {
            if (!IsOnBoard(from))
            {
                throw new NotOnBoardException($"Position with x:{from.X} and y:{from.Y} is not a field on the board");
            }

            if (!IsOnBoard(to))
            {
                throw new NotOnBoardException($"Position with x:{to.X} and y:{to.Y} is not a field on the board");
            }

            var possibleMoves = this[from]?.GetMoves(this, from);
            if (possibleMoves is not null && possibleMoves.Contains(to)) 
            {
                return true;
            }

            return false;

            // TODO
        }

        public IEnumerable<Position> GetMoves(Position position)
        {
            if (!IsOnBoard(position)) 
            {
                throw new NotOnBoardException($"Position with x:{position.X} and y:{position.Y} is not a field on the board");
            }

            var piece = this[position];

            return 
                piece is not null 
                ? piece.GetMoves(this, position) 
                : new List<Position>();
        }

        public BoardStateInfo? GetBoardStateInfo(Position position)
        {
            if (!IsOnBoard(position))
            {
                return null;
            }

            return new BoardStateInfo { State = this[position]?.Colour, Position = position };
        }

        public IEnumerable<BoardStateInfo> GetBoardStateInfo(params Position[] positions)
        {
            foreach (var position in positions)
            {
                if (GetBoardStateInfo(position) is { } boardStateInfo)
                {
                    yield return boardStateInfo;
                }
            }
        }

        public IEnumerable<BoardStateInfo> GetBoardStateInfoInDirection(Direction direction, Position position)
        {
            position += directionDeltas[direction];

            while (IsOnBoard(position))
            {
                if (GetBoardStateInfo(position) is { } boardStateInfo)
                {
                    yield return boardStateInfo;
                }

                position += directionDeltas[direction];
            }
        }

        // TODO rethink this and check if Builder pattern would be more appropriate
        // something like builder.AddPiece(...).AddPiece(...).AddPiece(...).BuildBoard();
        public static GameBoard GenerateBoard(int rows, int columns, IEnumerable<(IPiece, Position)> pieces)
        {
            IPiece[,] newBoard = new IPiece[rows, columns];
            var gameBoard = new GameBoard(newBoard);
            foreach (var piece in pieces)
            {
                gameBoard.AddPiece(piece.Item1, piece.Item2);
            }

            return gameBoard;
        }

        private GameBoard(IPiece?[,] board)
        {
            this.board = board;
        }

        private IPiece? this[Position position]
        {
            get { return board[position.X, position.Y]; }
            set { board[position.X, position.Y] = value; }
        }

        private bool IsOnBoard(Position position)
        {
            return
                -1 < position.X && position.X < board.Length && -1 < position.Y ||
                -1 < position.Y && position.Y < board.GetLength(1);
        }

        private void AddPiece(IPiece piece, Position position)
        {
            this[position] = piece;
        }
    }
}