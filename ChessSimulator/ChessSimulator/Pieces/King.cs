﻿using System.Collections.Generic;
using System.Linq;

namespace ChessSimulator.Pieces
{
    public class King : IPiece
    {
        public string Name { get => PieceNames.King; }

        public Colour Colour { get; }

        public King(Colour colour)
        {
            Colour = colour;
        }

        // Think how to enable castle move
        public Position[] GetMoves(IGameBoard gameBoard, Position position)
        {
            var positionsArround = GetPointsArround(position);
            var boardStateInfos = gameBoard.GetBoardStateInfo(positionsArround.ToArray());
            return boardStateInfos.Where(x => !x.State.HasValue || x.State != Colour).Select(x => x.Position).ToArray();
        }

        public IEnumerable<Position> GetPointsArround(Position position) 
        {
            var result = new List<Position>();
            int x = 0;
            int y = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    x = position.X + i;
                    y = position.Y + j;
                    if ((i != 0 || j != 0) && x > -1 && y > -1)
                    {
                        result.Add(new Position(x, y));
                    }
                }
            }

            return result;
        }
    }
}
