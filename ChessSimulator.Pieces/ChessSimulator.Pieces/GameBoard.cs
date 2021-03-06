using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessSimulator.Pieces
{
    public class GameBoard : IGameBoard
    {
        private readonly IPiece[,] board;

        private GameBoard(IPiece[,] board)
        {
            this.board = board;
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
            throw new NotImplementedException();
        }

        public BoardStateInfo GetBoardState(Position point)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BoardStateInfo> GetBoardStatesAround(Position point)
        {
            throw new NotImplementedException();
        }

        public IPiece RemovePiece(Position position)
        {
            throw new NotImplementedException();
        }
    }
}
