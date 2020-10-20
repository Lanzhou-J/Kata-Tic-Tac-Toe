namespace Tic_Tac_Toe
{
    public class Player
    {
        public Piece Piece { get; }
        public string Name { get; }

        public bool IsWinner { get; set; }

        public Player(Piece piece, string name)
        {
            Piece = piece;
            Name = name;
            IsWinner = false;
        }
    }
    
}