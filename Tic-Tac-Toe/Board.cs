using System;
using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    public class Board
    {
        public int Size { get; set; }
        public List<Cell> Cells { get; set; }

        public Board(int size)
        {
            Size = size;
            Cells = new List<Cell>();
            for (int row = 1; row <= Size; row++)
            {
                for (int col = 1; col <= Size; col++)
                {
                    Coord newCoord = new Coord(row, col);
                    Cell newCell = new Cell(newCoord);
                    this.Cells.Add(newCell);                    
                }
            }
        }

    }
}