using System;
using System.Text.RegularExpressions;
namespace Tic_Tac_Toe
{
    public class Game
    {
        private Player CurrentPlayer { get; set; }
        private Player Player1 { get; }
        private Player Player2 { get; }
        private Board GameBoard { get; }
        
        private readonly IInputOutput _iio;

        public Game(IInputOutput iio)
        {
            _iio = iio;
            GameBoard = new Board(3);
            Player1 = new Player(CellValue.X, "Player 1", _iio);
            Player2 = new Player(CellValue.O, "Player 2", _iio);
            CurrentPlayer = Player1;
        }
      
        public void Start()
        {
            try
            {
                WelcomePlayer();
                _iio.PrintBoard(GameBoard);
                TakeTurns();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        private void WelcomePlayer()
        {
            _iio.Output("Welcome to Tic Tac Toe!");
            _iio.Output("Here's the current board:");  
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
                Board updatedBoard = DetermineActionFromInput(playerInput);
                // Compare objects;
                if (updatedBoard != null)
                {
                    turn++;
                    _iio.PrintBoard(updatedBoard);
                    if (Rule.DetermineWin(updatedBoard, CurrentPlayer.CellValue))
                    {
                        _iio.Output($"The winner is {CurrentPlayer.Name}");
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
                    _iio.Output("It is a draw!");
                }
            }
        }
        private Board DetermineActionFromInput(string playerInput)
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
                // throw new ArgumentException($"The input: {playerInput} is not valid.",
                //     nameof(playerInput));
                _iio.Output("It is not a valid input.");
                return null;
            }

            return null;
        }

        // private IAction DetermineActionFromUserInput(string playerInput)
        // {
        //     if (playerInput == "q")
        //     {
        //         return new QuitAction();
        //     }
        //
        //     throw new InvalidEnumArgumentException();
        // }
        //
        // public void Play()
        // {
        //     //...
        //     try
        //     {
        //         var action = DetermineActionFromInput("");
        //         action.Act();
        //     }
        //     catch (InvalidEnumArgumentException e)
        //     {
        //         Console.WriteLine(e);
        //     }
        // }

        private void QuitGame(string player)
        {
            _iio.Output($"{player} quit the game.");
            Environment.Exit(1);
        }

        private Location CreateLocation(string locationInput)
        {
            char xValue = locationInput[0];
            char yValue = locationInput[2];
            int locationX = xValue - '0';
            int locationY = yValue - '0';
            Location newLocation = new Location(locationX, locationY);
            return newLocation;
        }
    }

    
    // internal interface IAction
    // {
    //     void Act();
    // }
    //
    // public class QuitAction : IAction
    // {
    //     public void Act()
    //     {
    //         Console.WriteLine("quit the game.");
    //         Environment.Exit(1);
    //     }
    // }
    //
    // public class MoveAction : IAction
    // {
    //     public void Act()
    //     {
    //         //update board
    //     }
    // }
}