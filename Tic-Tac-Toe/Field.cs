using System;

namespace Tic_Tac_Toe
{
    public class Field
    {
        private Boolean HasPiece { get; set; }
        private Coord Position { get; set; }
        private Piece Piece { get; set; }

        public Field()
        {
            HasPiece = false;
        }

        public Field AcceptMove()
        {
            this.HasPiece = true;
            return this;
        }

        private Piece CreatePiece()
        {
            return new Piece();
        }
    }
}