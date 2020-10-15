using System;

namespace Tic_Tac_Toe
{
    public class BoardOutput
    {
        private Board Board { get; set;}

        public BoardOutput(Board board)
        {
            Board = board;
        }

        public void Print()
        {
            for (int i = 1; i <= Board.Size; i++)
            {
                int row = Board.Size * (i - 1);
                for (int j = 1; j <= Board.Size; j++)
                {
                    int index = row + (j - 1);
                    Console.Write(Board.Cells[index].DisplayCellValue());
                    Console.Write(" "); 
                }
                Console.WriteLine("");
            }

        }
    }
}