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
                    Location newLocation = new Location(row, col);
                    Cell newCell = new Cell(newLocation);
                    this.Cells.Add(newCell);                    
                }
            }
        }

        public Board UpdateBoard(Location location, CellValue cellValue)
        {
            int index = this.Size * (location.RowValueX - 1) + (location.ColumnValueY - 1);
            if (this.Cells[index].Value == CellValue.Empty)
            {
                this.Cells[index].Value = cellValue;
                return this;
            }
            else
            {
                throw new ArgumentException($"{location} is not valid. The cell is not empty.",
                    nameof(location));
            }
        }
    }
}