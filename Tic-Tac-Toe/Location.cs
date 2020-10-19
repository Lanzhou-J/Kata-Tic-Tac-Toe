namespace Tic_Tac_Toe
{
    public class Location
    {
        public int RowValueX { get; }
        public int ColumnValueY { get; }
        
        public Location(int rowValueX, int columnValueY)
        {
            RowValueX = rowValueX;
            ColumnValueY = columnValueY;
        }
    }
}