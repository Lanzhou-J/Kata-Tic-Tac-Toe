using System;
using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    public class Board
    {
        public int Size { get; private set; }
        public List<Cell> Cells { get; private set; }

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

        private int GetCellIndexBasedOnLocation(Location location)
        {
            int index = Size * (location.RowValueX - 1) + (location.ColumnValueY - 1);
            return index;
        }

        public bool LocationCellIsEmpty(Location location)
        {
            int index = GetCellIndexBasedOnLocation(location);
            
            if (Cells[index].Value == CellValue.Empty)
            {
                return true;
            }
            
            return false;
        }

        // validation and updateboard
        public void UpdateBoard(Location location, CellValue cellValue)
        {
            int index = GetCellIndexBasedOnLocation(location);
            if (LocationCellIsEmpty(location))
            {
                Cells[index].Value = cellValue;
            }
            // else
            // {
                // throw new ArgumentException($"{location} is not valid. The cell is not empty.",
                //     nameof(location));
                // Console.WriteLine("Oh no, a piece is already at this place! Try again...");
                // return null;
            // }
        }
    }
}