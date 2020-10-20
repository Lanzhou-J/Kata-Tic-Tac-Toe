using System;
using System.Collections.Generic;
using System.Linq;

namespace Tic_Tac_Toe
{
    public class TicTacToeRule:IRule
    {
        private const int WinCount = 3;   
        public bool DetermineWin(Board gameBoard, CellValue cellValue)
        {
            var sameValueCells = gameBoard.Cells.FindAll(x => x.Value.Equals(cellValue));
            return CheckRow(sameValueCells)||CheckColumn(sameValueCells)||CheckDiagonal(sameValueCells);
        }

        private static bool CheckRow(IEnumerable<Cell> cells)
        {
            var rowValueXs = cells.Select(cell => cell.Position.RowValueX).ToList();
            rowValueXs.Sort();
            
            var count = rowValueXs.GroupBy(item => item).Where(item => item.Count() >= WinCount).Sum(item=> item.Count());
            return count == WinCount;
        }
        
        private static bool CheckColumn(IEnumerable<Cell> cells)
        {
            var columnValueYs = cells.Select(cell => cell.Position.ColumnValueY).ToList();
            columnValueYs.Sort();
            var count = columnValueYs.GroupBy(item => item).Where(item => item.Count() >= WinCount).Sum(item=> item.Count());
            return count == WinCount;
        }

        private static bool CheckDiagonal(IEnumerable<Cell> cells)
        {
            var topLeftToBottomRightCount = 0;
            var bottomLeftToTopRightCount = 0;
            foreach (var cell in cells)
            {
                if (cell.Position.ColumnValueY == cell.Position.RowValueX)
                {
                    topLeftToBottomRightCount++;
                }
                if (cell.Position.ColumnValueY + cell.Position.RowValueX == 4)
                {
                    bottomLeftToTopRightCount++;
                }
            }
            return topLeftToBottomRightCount == WinCount || bottomLeftToTopRightCount == WinCount;
        }
    }
}