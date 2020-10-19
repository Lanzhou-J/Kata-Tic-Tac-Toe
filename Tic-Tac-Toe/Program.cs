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
            var newGame = new Game(console);
            newGame.Play();
        }
    }
}