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
            // Board newBoard = new Board(3);
            //
            // var boardOutput = new BoardOutput(newBoard);
            // boardOutput.Print();
            // Coord newCoord = new Coord(3,1);
            // Board updatedBoard = newBoard.UpdateBoard(newCoord, CellValue.X);
            // boardOutput = new BoardOutput(updatedBoard);
            // boardOutput.Print();
            Game newGame = new Game();
            newGame.Start();
            
        }
    }
}