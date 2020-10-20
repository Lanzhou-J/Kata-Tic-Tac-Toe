namespace Tic_Tac_Toe
{
    public class Cell
    {
        public Location Position { get; }
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
            return Value switch
            {
                CellValue.X => "X",
                CellValue.O => "O",
                _ => "."
            };
        }

    }
}