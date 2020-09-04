using System;

namespace Tic_Tac_Toe
{
    public class Cell
    {
        public Coord Position { get; set; }
        public CellValue Value { get; set; }

        public Cell()
        {
            Value = CellValue.Empty;
        }
        
        public Cell(Coord position)
        {
            Position = position;
            Value = CellValue.Empty;
        }

        public Cell (Coord position, CellValue cellValue)
        {
            Position = position;
            Value = cellValue;
        }

        public string DisplayCellValue()
        {
            if (Value == CellValue.X)
            {
                return "X";
            }else if (Value == CellValue.O)
            {
                return "O";
            }
            else
            {
                return ".";
            }
        }

    }
}