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
            Board newBoard = new Board(3);
            foreach (var cell in newBoard.Cells)
            {
                var position = cell.Position;
                Console.WriteLine("({0},{1},{2})",position.RowValueX, position.ColumnValueY, cell.Value);
            }
            
        }
    }
}