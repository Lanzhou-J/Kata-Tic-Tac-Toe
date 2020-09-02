using System;
using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    static class Program
    {
        static void Main(string[] args)
        {
            Board newBoard = new Board();
            Board board = newBoard.CreateBoard();
            foreach (var field in board.FieldList)
            {
                var position = field.Position;
                Console.WriteLine("({0},{1})",position.RowValueX, position.ColumnValueY);
            }
            
        }
    }
}