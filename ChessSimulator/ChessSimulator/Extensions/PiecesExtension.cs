using ChessSimulator.Enums;
using ChessSimulator.Gameboards;
using System.Collections.Generic;

namespace ChessSimulator.Extensions
{
    internal static class PiecesExtension
    {
        internal static IList<Position> GetPositionsUntilNotFree(this IList<Position> positions, IEnumerable<BoardStateInfo> boardStateInfos, Colour colour)
        {
            foreach (var info in boardStateInfos)
            {
                if (info.State is null)
                {
                    positions.Add(info.Position);
                }
                else if (info.State != colour)
                {
                    positions.Add(info.Position);
                    break;
                }
                else
                {
                    break;
                }
            }

            return positions;
        }
    }
}
