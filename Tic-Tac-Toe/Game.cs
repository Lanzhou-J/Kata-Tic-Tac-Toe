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
                PlayerInput newInput = new PlayerInput();
                string playerInput = newInput.CollectPlayerInput(CurrentPlayer.Name, CurrentPlayer.CellValue.ToString());
                Board updatedBoard = SortInput(playerInput);
                if (updatedBoard != null)
                {
                    turn++;
                }
                else
                {
                    updatedBoard = previousBoard;
                }
                BoardOutput newBoardOutput = new BoardOutput(updatedBoard);
                newBoardOutput.Print();
                previousBoard = updatedBoard;
            }
        }
        private dynamic SortInput(string playerInput)
        {
            string pattern = @"^[1-3],[1-3]$";
            if (playerInput == "q")
            {
                QuitGame(CurrentPlayer.Name);
            }else if (Regex.IsMatch(playerInput, pattern))
            {
                Coord newCoord = CreateCoord(playerInput);
                Board updatedBoard = GameBoard.UpdateBoard(newCoord, CurrentPlayer.CellValue);
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

        private Coord CreateCoord(string coordInput)
        {
            char xValue = coordInput[0];
            char yValue = coordInput[2];
            int coordX = (int) (xValue - '0');
            int coordY = (int) (yValue - '0');
            Coord newCoord = new Coord(coordX, coordY);
            return newCoord;
        }



    }
}