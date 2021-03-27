using System;

namespace ChessSimulator.Extensions
{
    public static class BoardParser
    {
        public static Position Parse(this string position)
        {
            switch (position)
            {
                case "A8":
                    return new Position(0, 0);
                case "A7":
                    return new Position(0, 1);
                case "A6":
                    return new Position(0, 2);
                case "A5":
                    return new Position(0, 3);
                case "A4":
                    return new Position(0, 4);
                case "A3":
                    return new Position(0, 5);
                case "A2":
                    return new Position(0, 6);
                case "A1":
                    return new Position(0, 7);

                case "B8":
                    return new Position(1, 0);
                case "B7":
                    return new Position(1, 1);
                case "B6":
                    return new Position(1, 2);
                case "B5":
                    return new Position(1, 3);
                case "B4":
                    return new Position(1, 4);
                case "B3":
                    return new Position(1, 5);
                case "B2":
                    return new Position(1, 6);
                case "B1":
                    return new Position(1, 7);

                case "C8":
                    return new Position(2, 0);
                case "C7":
                    return new Position(2, 1);
                case "C6":
                    return new Position(2, 2);
                case "C5":
                    return new Position(2, 3);
                case "C4":
                    return new Position(2, 4);
                case "C3":
                    return new Position(2, 5);
                case "C2":
                    return new Position(2, 6);
                case "C1":
                    return new Position(2, 7);

                case "D8":
                    return new Position(3, 0);
                case "D7":
                    return new Position(3, 1);
                case "D6":
                    return new Position(3, 2);
                case "D5":
                    return new Position(3, 3);
                case "D4":
                    return new Position(3, 4);
                case "D3":
                    return new Position(3, 5);
                case "D2":
                    return new Position(3, 6);
                case "D1":
                    return new Position(3, 7);

                case "E8":
                    return new Position(4, 0);
                case "E7":
                    return new Position(4, 1);
                case "E6":
                    return new Position(4, 2);
                case "E5":
                    return new Position(4, 3);
                case "E4":
                    return new Position(4, 4);
                case "E3":
                    return new Position(4, 5);
                case "E2":
                    return new Position(4, 6);
                case "E1":
                    return new Position(4, 7);

                case "F8":
                    return new Position(5, 0);
                case "F7":
                    return new Position(5, 1);
                case "F6":
                    return new Position(5, 2);
                case "F5":
                    return new Position(5, 3);
                case "F4":
                    return new Position(5, 4);
                case "F3":
                    return new Position(5, 5);
                case "F2":
                    return new Position(5, 6);
                case "F1":
                    return new Position(5, 7);

                case "G8":
                    return new Position(6, 0);
                case "G7":
                    return new Position(6, 1);
                case "G6":
                    return new Position(6, 2);
                case "G5":
                    return new Position(6, 3);
                case "G4":
                    return new Position(6, 4);
                case "G3":
                    return new Position(6, 5);
                case "G2":
                    return new Position(6, 6);
                case "G1":
                    return new Position(6, 7);

                case "H8":
                    return new Position(7, 0);
                case "H7":
                    return new Position(7, 1);
                case "H6":
                    return new Position(7, 2);
                case "H5":
                    return new Position(7, 3);
                case "H4":
                    return new Position(7, 4);
                case "H3":
                    return new Position(7, 5);
                case "H2":
                    return new Position(7, 6);
                case "H1":
                    return new Position(7, 7);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
