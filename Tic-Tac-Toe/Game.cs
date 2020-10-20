using System.Text.RegularExpressions;

namespace Tic_Tac_Toe
{
    public class Game
    {
        private int _turn = 1;
        private readonly IInputOutput _iio;
        private readonly IRule _rule;
        private Player CurrentPlayer { get; set; }
        private Player Player1 { get; }
        private Player Player2 { get; }
        private Board GameBoard { get; }

        public GameState GameState { get; private set; }
        
        public Game(IInputOutput iio, IRule rule, Player player1, Player player2, GameState gameState = GameState.Continue)
        {
            _iio = iio;
            _rule = rule;
            GameState = gameState;
            GameBoard = new Board(3);
            Player1 = player1;
            Player2 = player2;
            CurrentPlayer = Player1;
        }
        
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

        private void UpdateGameState()
        {
            while (GameState == GameState.Continue)
            {
                DetermineWhoIsCurrentPlayer();
                var playerInput = _iio.CollectPlayerInput(CurrentPlayer);
                DetermineActionFromInput(playerInput);

                if (_turn <= GameBoard.Size * GameBoard.Size) continue;
                GameState = GameState.Draw;
                _iio.Output("It is a draw!");
            }
        }

        private void DetermineWhoIsCurrentPlayer()
        {
            CurrentPlayer = _turn % 2 == 0 ? Player2 : Player1;
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
                    if (_rule.DetermineWin(GameBoard, CurrentPlayer.CellValue))
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