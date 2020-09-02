namespace Tic_Tac_Toe
{
    public class Coord
    {
        private int RowValueX { get; set; }
        private int ColumnValueY { get; set; }
        
        public Coord(int rowValueX, int columnValueY)
        {
            RowValueX = rowValueX;
            ColumnValueY = columnValueY;
        }

        public Coord()
        {
        }

        public Coord GetValidCoord()
        {
            return new Coord();
        }



    }
}