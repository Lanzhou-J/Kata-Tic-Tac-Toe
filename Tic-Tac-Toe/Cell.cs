namespace Tic_Tac_Toe
{
    public class Cell
    {
        public Location Position { get; private set; }
        public CellValue Value { get; set; }

        public Cell(Location position)
        {
            Position = position;
            Value = CellValue.Empty;
        }

        public Cell (Location position, CellValue cellValue)
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