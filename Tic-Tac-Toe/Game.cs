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
            CurrentPlayer = null;
            GameState = gameState;
            GameBoard = new Board(3);
            Player1 = new Player(CellValue.X, "Player 1");
            Player2 = new Player(CellValue.O, "Player 2");
        }

        public GameState Play()
        {
            return GameState;
        }

    }
}