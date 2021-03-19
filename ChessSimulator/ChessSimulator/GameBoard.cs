using ChessSimulator.Pieces;
using System;
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

        private bool IsOnBoard(Position position)
        {
            return -1 < position.X && position.X < board.Length && -1 < position.Y || -1 < position.Y && position.Y < board.GetLength(1);
        }

        private Colour? GetBoardState(Position position)
        {
            return board[position.X, position.Y]?.Colour;
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

        public IEnumerable<BoardStateInfo> GetBoardStateInfoInDirection(Direction direction, Position[] positions)
        {
            Position northDelta = new Position(0, -1);
            Position eastDelta = new Position(1, 0);
            Position southDelta = new Position(0, 1);
            Position westDelta = new Position(-1, 0);

            Position northEastDelta = new Position(1, -1);
            Position NorthWestDelta = new Position(-1, -1);
            Position SouthEastDelta = new Position(1, 1);
            Position SouthWestDelta = new Position(-1, 1);

            throw new NotImplementedException();
        }
    }
}
