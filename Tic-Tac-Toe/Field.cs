using System;

namespace Tic_Tac_Toe
{
    public class Field
    {
        public Boolean HasPiece { get; set; }
        public Coord Position { get; set; }
        private Piece Piece { get; set; }

        public Field()
        {
            HasPiece = false;
        }
        
        public Field(Coord position)
        {
            HasPiece = false;
            Position = position;
        }

        public Field AcceptMove()
        {
            this.HasPiece = true;
            return this;
        }

        private Piece CreatePiece()
        {
            return new Piece(this.Position, value:Game.CurrentPlayer.Value);
        }
    }
}