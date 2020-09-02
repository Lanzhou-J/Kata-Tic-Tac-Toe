using System;
using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    public class Board
    {
        public static int Size { get; set; }
        public List<Field> FieldList { get; set; }

        public Board()
        {
            Size = 3;
            FieldList = new List<Field>();
        }

        public Board(List<Field> fieldList)
        {
            FieldList = fieldList;
            Size = 3;
        }

        public Board CreateBoard()
        {
            for (int row = 1; row <= Size; row++)
            {
                for (int col = 1; col <= Size; col++)
                {
                    Coord newCoord = new Coord(row, col);
                    Field newField = new Field(newCoord);
                    this.FieldList.Add(newField);                    
                }
            }
            return new Board(FieldList);
        }
    }
}