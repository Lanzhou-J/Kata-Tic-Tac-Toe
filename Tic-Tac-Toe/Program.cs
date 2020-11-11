namespace Tic_Tac_Toe
{

    static class Program
    {
        static void Main()
        {
            var console = new ConsoleInputOutput();
            var ticTacToeRule = new TicTacToeRule();
            var player1 = new Player(Piece.X, "Player 1");
            var player2 = new Player(Piece.O, "Player 2");
            var newGame = new Game(console, ticTacToeRule, player1, player2);
            newGame.Play();
        }
    }
}