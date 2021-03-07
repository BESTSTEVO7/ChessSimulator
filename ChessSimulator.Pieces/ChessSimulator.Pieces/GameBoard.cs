using System;
using System.Collections.Generic;

namespace ChessSimulator.Pieces
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

        public BoardStateInfo GetBoardState(Position position)
        {
            if (this[position] is { })
            {
                return new BoardStateInfo { State = this[position].Colour, Position = position };
            }

            return new BoardStateInfo { Position = position };
        }

        public IEnumerable<BoardStateInfo> GetBoardStatesAround(Position point)
        {
            throw new NotImplementedException();
        }
    }
}
