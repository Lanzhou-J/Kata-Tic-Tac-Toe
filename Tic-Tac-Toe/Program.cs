using System;
using System.Collections.Generic;

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
        static void Main(string[] args)
        {
            var console = new ConsoleInputOutput();
            Game newGame = new Game(console);
            newGame.Start();
            
        }
    }
}