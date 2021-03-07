using ChessSimulator.Pieces;
using System.Collections.Generic;

namespace ChessSimulator
{
    public class GameBoard : IGameBoard
    {
        private readonly IPiece[,] board;

        private GameBoard(IPiece[,] board)
        {
            this.board = board;
        }

        private IPiece this[Position position]
        {
            get { return board[position.X, position.Y]; }
            set { board[position.X, position.Y] = value; }
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
            if (this[position] is { })
            {
                return new BoardStateInfo { State = this[position].Colour, Position = position };
            }

            return new BoardStateInfo { Position = position };
        }

        public IEnumerable<BoardStateInfo> GetBoardStatesAround(Position point)
        {
            var result = new List<BoardStateInfo>();
            int x = 0;
            int y = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    x = point.X + i;
                    y = point.Y + j;
                    // not the point and valid coordinates on the board
                    if ((i != 0 || j != 0) && IsOnBoard(x, y))
                    {
                        result.Add(new BoardStateInfo { Position = new Position(x, y), State = GetBoardState(x, y) });
                    }
                }
            }
            return result;
        }

        private bool IsOnBoard(Position position)
        {
            return IsOnBoard(position.X, position.Y);
        }

        private bool IsOnBoard(int x, int y)
        {
            return -1 < x && x < board.Length && -1 < y || -1 < y && y < board.GetLength(1);
        }

        private Colour? GetBoardState(Position position)
        {
            return GetBoardState(position.X, position.Y);
        }

        private Colour? GetBoardState(int x, int y)
        {
            return board[x, y]?.Colour;
        }
    }
}
