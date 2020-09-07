using System;
namespace Tic_Tac_Toe
{
    public class Game
    {
        public Player CurrentPlayer { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Board GameBoard { get; private set; }

        public Game()
        {
            GameBoard = new Board(3);
            Player1 = new Player(CellValue.X, "Player 1");
            Player2 = new Player(CellValue.O, "Player 2");
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("Here's the current board:");
            BoardOutput newBoardOutput = new BoardOutput(GameBoard);
            newBoardOutput.Print();
        }

    }
}