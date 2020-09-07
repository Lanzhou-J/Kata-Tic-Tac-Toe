using System;

namespace Tic_Tac_Toe
{
    public class Coord
    {
        public int RowValueX { get; set; }
        public int ColumnValueY { get; set; }
        
        public Coord(int rowValueX, int columnValueY)
        {
            RowValueX = rowValueX;
            ColumnValueY = columnValueY;
        }

        public Coord()
        {
        }

    }
}