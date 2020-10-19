namespace Tic_Tac_Toe
{
    public enum CellValue
    {
        Empty,
        X,
        O
    }

    static class Program
    {
        static void Main()
        {
            var console = new ConsoleInputOutput();
            var ticTacToeRule = new TicTacToeRule();
            var player1 = new Player(CellValue.X, "Player 1");
            var player2 = new Player(CellValue.O, "Player 2");
            var newGame = new Game(console, ticTacToeRule, player2, player1);
            newGame.Play();
        }
    }
}