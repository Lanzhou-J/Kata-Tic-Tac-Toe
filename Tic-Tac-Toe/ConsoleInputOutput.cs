using System;

namespace Tic_Tac_Toe
{
    public class ConsoleInputOutput: IInputOutput
    {
        public string Ask(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
        
        public void Output(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintBoard(Board board)
        {
            for (int i = 1; i <= board.Size; i++)
            {
                int row = board.Size * (i - 1);
                for (int j = 1; j <= board.Size; j++)
                {
                    int index = row + (j - 1);
                    Console.Write(board.Cells[index].DisplayCellValue());
                    Console.Write(" "); 
                }
                Console.WriteLine("");
            }

        }
        
    }
}