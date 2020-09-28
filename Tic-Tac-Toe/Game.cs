using System;
using System.Text.RegularExpressions;
namespace Tic_Tac_Toe
{
    public class Game
    {
        private Player CurrentPlayer { get; set; }
        private Player Player1 { get; set; }
        private Player Player2 { get; set; }
        private Board GameBoard { get; set; }

        public Game()
        {
            GameBoard = new Board(3);
            Player1 = new Player(CellValue.X, "Player 1");
            Player2 = new Player(CellValue.O, "Player 2");
            CurrentPlayer = Player1;
        }
        // move BoardOutput to Program.cs
        // and use boardoutput as an argument in Start method (IPrintBoard xxx)
        public void Start()
        {
            WelcomePlayer();
            BoardOutput newBoardOutput = new BoardOutput(GameBoard);
            newBoardOutput.Print();
            TakeTurns();
        }

        private void WelcomePlayer()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("Here's the current board:");  
        }

        private void TakeTurns()
        {
            Board previousBoard = GameBoard;
            int turn = 1;
            while (turn <= GameBoard.Size*GameBoard.Size)  
            {
                if (turn % 2 == 0)
                {
                    CurrentPlayer = Player2;
                }
                else
                {
                    CurrentPlayer = Player1;
                }
                
                string playerInput = CurrentPlayer.CollectPlayerInput();
                Board updatedBoard = SortInput(playerInput);
                // Compare objects;
                if (updatedBoard != null)
                {
                    turn++;
                    BoardOutput newBoardOutput = new BoardOutput(updatedBoard);
                    newBoardOutput.Print();
                    if (Rule.DetermineWin(updatedBoard, CurrentPlayer.CellValue))
                    {
                        Console.WriteLine($"The winner is {CurrentPlayer.Name}");
                        Environment.Exit(1);
                    }
                }
                else
                {
                    updatedBoard = previousBoard;
                }
                previousBoard = updatedBoard;
                if (turn>9)
                {
                    Console.WriteLine("It is a draw!");
                }
            }
        }
        private Board SortInput(string playerInput)
        {
            
            string pattern = $@"^[1-{GameBoard.Size}],[1-{GameBoard.Size}]$";
            if (playerInput == "q")
            {
                QuitGame(CurrentPlayer.Name);
            }else if (Regex.IsMatch(playerInput, pattern))
            {
                Location newLocation = CreateLocation(playerInput);
                Board updatedBoard = GameBoard.UpdateBoard(newLocation, CurrentPlayer.CellValue);
                return updatedBoard;
            }
            else
            {
                Console.WriteLine("It is not a valid input.");
                return null;
            }

            return null;
        }

        private void QuitGame(string player)
        {
            Console.WriteLine($"{player} quit the game.");
            Environment.Exit(1);
        }

        private Location CreateLocation(string locationInput)
        {
            char xValue = locationInput[0];
            char yValue = locationInput[2];
            int locationX = (int) (xValue - '0');
            int locationY = (int) (yValue - '0');
            Location newLocation = new Location(locationX, locationY);
            return newLocation;
        }
    }
}