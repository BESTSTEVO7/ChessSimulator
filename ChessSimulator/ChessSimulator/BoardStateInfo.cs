using ChessSimulator.Enums;

namespace ChessSimulator
{
    public class BoardStateInfo
    {
        public Position Position { get; set; }

        public Colour? State { get; set; }

        public string? Representation;
    }
}
