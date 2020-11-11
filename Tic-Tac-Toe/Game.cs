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
            WelcomePlayers();
            OutputBoard();
            PlayersTakeTurnsToPlay();
        }
        
        private void WelcomePlayers()
        {
            _iio.Output("Welcome to Tic Tac Toe!");
        }
        private void OutputBoard()
        {
            _iio.Output("Here's the current board:");
            _iio.Output(GameBoard);
        }
        private void PlayersTakeTurnsToPlay()
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
            if (PlayerInputMatchesQuitResponse(playerInput))
            {
                QuitGame();
            }else if (PlayerInputMatchesLocationStringPattern(playerInput))
            {
                var newLocation = CreateLocationBasedOnLocationInput(playerInput);
                if (GameBoard.LocationCellIsEmpty(newLocation))
                {
                    CurrentPlayerMakeAMove(newLocation);
                    OutputBoard();
                    CheckWinner();
                }
                else
                {
                    RemindPlayerLocationCellIsTaken();
                }
            }
            else
            {
                RemindPlayerInputIsNotValid();
            }
        }

        private static bool PlayerInputMatchesQuitResponse(string playerInput)
        {
            return playerInput == QuitResponse;
        }

        private void QuitGame()
        {
            _iio.Output($"{CurrentPlayer.Name} quit the game.");
            GameState = GameState.Quit;
        }
        
        private bool PlayerInputMatchesLocationStringPattern(string playerInput)
        {
            var locationStringPattern = $@"^[1-{GameBoard.Size}],[1-{GameBoard.Size}]$";
            return Regex.IsMatch(playerInput, locationStringPattern);
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
        private void CurrentPlayerMakeAMove(Location newLocation)
        {
            GameBoard.UpdateBoard(newLocation, CurrentPlayer.Piece);
            _turn++;
        }
        private void CheckWinner()
        {
            if (_rule.DetermineWin(GameBoard, CurrentPlayer.Piece))
            {
                _iio.Output($"The winner is {CurrentPlayer.Name}");
                CurrentPlayer.IsWinner = true;
                GameState = GameState.PlayerWon;
            }
        }
        private void RemindPlayerLocationCellIsTaken()
        {
            _iio.Output("Oh no, a piece is already at this place! Try again...");
        }
        private void RemindPlayerInputIsNotValid()
        {
            _iio.Output("It is not a valid input.");
        }
        
        private void DetermineIfItIsADraw()
        {
            if (_turn <= GameBoard.Size * GameBoard.Size) return;
            GameState = GameState.Draw;
            _iio.Output("It is a draw!");
        }
    }
}