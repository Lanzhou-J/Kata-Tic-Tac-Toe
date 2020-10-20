namespace Tic_Tac_Toe
{
    public class Cell
    {
        public Location Location { get; }
        public Piece Value { get; set; }

        public Cell(Location location)
        {
            Location = location;
            Value = Piece.None;
        }

        public Cell (Location location, Piece piece)
        {
            Location = location;
            Value = piece;
        }

        public string DisplayCellValue()
        {
            return Value switch
            {
                Piece.X => "X",
                Piece.O => "O",
                _ => "."
            };
        }

    }
}