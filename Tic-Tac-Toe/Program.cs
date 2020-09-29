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
            Game newGame = new Game();
            newGame.Start();
            
        }
    }
}