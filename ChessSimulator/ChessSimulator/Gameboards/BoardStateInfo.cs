using ChessSimulator.Enums;

namespace ChessSimulator.Gameboards
{
    public class BoardStateInfo
    {
        public Position Position { get; set; }

        public Colour? State { get; set; }

        public string? Representation;
    }
}
