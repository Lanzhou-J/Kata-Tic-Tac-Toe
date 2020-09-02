using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    public class Board
    {
        public static int Size { get; set; }
        private List<Field> FieldList { get; set; }

        public Board()
        {
            Size = 3;
        }

        public Board CreateBoard()
        {
            return new Board();
        }
    }
}