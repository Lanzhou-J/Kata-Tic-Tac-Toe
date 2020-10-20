namespace Tic_Tac_Toe
{
    public interface IRule
    {
        public bool DetermineWin(Board gameBoard, Piece piece);
    }
}