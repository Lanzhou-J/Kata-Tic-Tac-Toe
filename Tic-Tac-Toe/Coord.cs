using System;

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
            if (RowValueX < 0 || RowValueX > Board.Size)
            {
                throw new Exception("Invalid coord X value.");
            }

            if (ColumnValueY < 0 || ColumnValueY > Board.Size)
            {
                throw new Exception("Invalid Coord Y value.");
            }

            return new Coord();
        }



    }
}