using ChessSimulator.Pieces;
using System.Collections.Generic;

namespace ChessSimulator
{
    public class GameBoard : IGameBoard
    {
        private readonly IPiece[,] board;

        private static readonly IReadOnlyDictionary<Direction, Position> directionDeltas =
            new Dictionary<Direction, Position>
            {
                {
                    Direction.North, new Position(0, -1)
                },
                {
                    Direction.East, new Position(0, -1)
                },
                {
                    Direction.South, new Position(0, -1)
                },
                {
                    Direction.West, new Position(0, -1)
                },
                {
                    Direction.NorthEast, new Position(0, -1)
                },
                {
                    Direction.NorthWest, new Position(0, -1)
                },
                {
                    Direction.SouthEast, new Position(0, -1)
                },
                {
                    Direction.SouthWest, new Position(0, -1)
                }
            };

        private GameBoard(IPiece[,] board)
        {
            this.board = board;
        }

        private IPiece this[Position position]
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

        public void AddPiece(IPiece piece, Position position)
        {
            this[position] = piece;
        }

        public void RemovePiece(Position position)
        {
            this[position] = null;
        }

        public BoardStateInfo GetBoardStateInfo(Position position)
        {
            if (!IsOnBoard(position))
            {
                return null;
            }

            if (this[position] is { })
            {
                return new BoardStateInfo { State = this[position].Colour, Position = position };
            }

            return new BoardStateInfo { Position = position };
        }

        public IEnumerable<BoardStateInfo> GetBoardStateInfo(params Position[] positions)
        {
            var result = new List<BoardStateInfo>();
            foreach (var position in positions)
            {
                result.Add(GetBoardStateInfo(position));
            }

            return result;
        }

        public IEnumerable<BoardStateInfo> GetBoardStateInfoInDirection(Direction direction, Position position)
        {
            var result = new List<BoardStateInfo>();
            position += directionDeltas[direction];

            while (IsOnBoard(position))
            {
                result.Add(GetBoardStateInfo(position));
                position += directionDeltas[direction];
            }

            return result;
        }
    }
}
