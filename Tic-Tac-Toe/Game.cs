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

        public GameState GameState { get; private set; }

        private readonly IInputOutput _iio;

        public Game(IInputOutput iio, GameState gameState = GameState.Continue)
        {
            _iio = iio;
            GameState = gameState;
            GameBoard = new Board(3);
            Player1 = new Player(CellValue.X, "Player 1");
            Player2 = new Player(CellValue.O, "Player 2");
            CurrentPlayer = Player1;
        }

        private int _turn = 1;

        public void Play()
        {
            WelcomePlayer();
            _iio.Output(GameBoard);
            UpdateGameState();
        }
        
        private void WelcomePlayer()
        {
            _iio.Output("Welcome to Tic Tac Toe!");
            _iio.Output("Here's the current board:");
        }

        private GameState UpdateGameState()
        {
            while (GameState == GameState.Continue)
            {
                CurrentPlayer = _turn % 2 == 0 ? Player2 : Player1;
                string playerInput = _iio.CollectPlayerInput(CurrentPlayer);
                DetermineActionFromInput(playerInput);
                
                if (_turn > GameBoard.Size * GameBoard.Size)
                {
                    GameState = GameState.Draw;
                    _iio.Output("It is a draw!");
                }
            }
            
            return GameState;
        }

        private void DetermineActionFromInput(string playerInput)
        {
            string pattern = $@"^[1-{GameBoard.Size}],[1-{GameBoard.Size}]$";
            if (playerInput == "q")
            {
                _iio.Output($"{CurrentPlayer.Name} quit the game.");
                GameState = GameState.Quit;
            }else if (Regex.IsMatch(playerInput, pattern))
            {
                Location newLocation = CreateLocation(playerInput);
                if (GameBoard.LocationCellIsEmpty(newLocation))
                {
                    GameBoard.UpdateBoard(newLocation, CurrentPlayer.CellValue);
                    _turn++;
                    _iio.Output(GameBoard);
                    if (Rule.DetermineWin(GameBoard, CurrentPlayer.CellValue))
                    {
                        _iio.Output($"The winner is {CurrentPlayer.Name}");
                        CurrentPlayer.IsWinner = true;
                        GameState = GameState.PlayerWon;
                    }
                }
                else
                {
                    _iio.Output("Oh no, a piece is already at this place! Try again...");
                }
            }
            else
            {
                _iio.Output("It is not a valid input.");
            }
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
}