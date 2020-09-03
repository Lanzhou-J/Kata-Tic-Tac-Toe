using System;

namespace Tic_Tac_Toe
{
    public class Cell
    {
        public Boolean HasPiece { get; set; }
        public Coord Position { get; set; }
        private Piece Piece { get; set; }

        public Cell()
        {
            HasPiece = false;
        }
        
        public Cell(Coord position)
        {
            HasPiece = false;
            Position = position;
        }

        public Cell AcceptMove()
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