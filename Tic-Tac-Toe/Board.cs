using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    public class Board
    {
        public int Size { get; }
        public List<Cell> Cells { get; }

        public Board(int size)
        {
            Size = size;
            Cells = new List<Cell>();
            AddNewCellToCells();
        }

        private void AddNewCellToCells()
        {
            for (var row = 1; row <= Size; row++)
            {
                for (var col = 1; col <= Size; col++)
                {
                    var newLocation = new Location(row, col);
                    var newCell = new Cell(newLocation);
                    Cells.Add(newCell);
                }
            }
        }

        public bool LocationCellIsEmpty(Location location)
        {
            var index = GetCellIndexBasedOnLocation(location);
            return Cells[index].Value == Piece.None;
        }
        
        public void UpdateBoard(Location location, Piece piece)
        {
            var index = GetCellIndexBasedOnLocation(location);
            if (LocationCellIsEmpty(location))
            {
                Cells[index].Value = piece;
            }
        }
        
        private int GetCellIndexBasedOnLocation(Location location)
        {
            var index = Size * (location.Row - 1) + (location.Column - 1);
            return index;
        }
    }
}