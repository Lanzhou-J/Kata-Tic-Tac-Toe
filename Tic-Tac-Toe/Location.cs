namespace Tic_Tac_Toe
{
    public class Location
    {
        public int RowValueX { get; set; }
        public int ColumnValueY { get; set; }
        
        public Location(int rowValueX, int columnValueY)
        {
            RowValueX = rowValueX;
            ColumnValueY = columnValueY;
        }

        public Location()
        {
        }

    }
}