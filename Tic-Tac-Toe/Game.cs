using System.Text.RegularExpressions;

namespace Tic_Tac_Toe
{
    public class Game
    {
        private const string QuitResponse = "q";
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
                DetermineIfItIsADraw();
            }
        }
        private void DetermineWhoIsCurrentPlayer()
        {
            CurrentPlayer = _turn % 2 == 0 ? Player2 : Player1;
        }
        
        private void DetermineActionFromInput(string playerInput)
        {
            var locationStringPattern = $@"^[1-{GameBoard.Size}],[1-{GameBoard.Size}]$";
            if (playerInput == QuitResponse)
            {
                QuitGame();
            }else if (PlayerInputMatchesLocationStringPattern(playerInput, locationStringPattern))
            {
                var newLocation = CreateLocationBasedOnLocationInput(playerInput);
                if (GameBoard.LocationCellIsEmpty(newLocation))
                {
                    MakeAMove(newLocation);
                    CheckWinner();
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
        
        private void QuitGame()
        {
            _iio.Output($"{CurrentPlayer.Name} quit the game.");
            GameState = GameState.Quit;
        }
        
        private static bool PlayerInputMatchesLocationStringPattern(string playerInput, string locationPattern)
        {
            return Regex.IsMatch(playerInput, locationPattern);
        }
        private static Location CreateLocationBasedOnLocationInput(string locationInput)
        {
            var xValue = locationInput[0];
            var yValue = locationInput[2];
            var locationX = xValue - '0';
            var locationY = yValue - '0';
            var newLocation = new Location(locationX, locationY);
            return newLocation;
        }
        private void MakeAMove(Location newLocation)
        {
            GameBoard.UpdateBoard(newLocation, CurrentPlayer.CellValue);
            _turn++;
            _iio.Output(GameBoard);
        }
        private void CheckWinner()
        {
            if (_rule.DetermineWin(GameBoard, CurrentPlayer.CellValue))
            {
                _iio.Output($"The winner is {CurrentPlayer.Name}");
                CurrentPlayer.IsWinner = true;
                GameState = GameState.PlayerWon;
            }
        }

        private void DetermineIfItIsADraw()
        {
            if (_turn <= GameBoard.Size * GameBoard.Size) return;
            GameState = GameState.Draw;
            _iio.Output("It is a draw!");
        }
    }
}