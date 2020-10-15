namespace Tic_Tac_Toe
{
    public class Location
    {
        public int RowValueX { get; private set; }
        public int ColumnValueY { get; private set; }
        
        public Location(int rowValueX, int columnValueY)
        {
            RowValueX = rowValueX;
            ColumnValueY = columnValueY;
        }
    }
}