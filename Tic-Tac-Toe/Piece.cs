using System;
using System.Runtime.Intrinsics.X86;

namespace Tic_Tac_Toe
{
    public class Piece
    {
        public enum PieceValue
        {
            X,
            O
        }
        private Coord Position { get; set; }
        private PieceValue Value { get; set; }

        public Piece(Coord position, PieceValue value)
        {
            Position = position;
            Value = value;
        }
    }
}