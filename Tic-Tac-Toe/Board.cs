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

        public Board UpdateBoard(Coord coord, CellValue cellValue)
        {
            int index = this.Size * (coord.RowValueX - 1) + (coord.ColumnValueY - 1);
            if (this.Cells[index].Value == CellValue.Empty)
            {
                this.Cells[index].Value = cellValue;
                return this;
            }
            else
            {
                Console.WriteLine("Oh no, a piece is already at this place! Try again...");
                return null;
            }
        }
    }
}