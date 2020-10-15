using System;
using System.Collections.Generic;
using System.Linq;

namespace Tic_Tac_Toe
{
    public static class Rule
    {
        
        public static Boolean DetermineWin(Board gameBoard, CellValue cellValue)
        {
            List<Cell> sameValueCells = gameBoard.Cells.FindAll(x => x.Value.Equals(cellValue));
            if (CheckRow(sameValueCells)||CheckColumn(sameValueCells)||CheckDiagonal(sameValueCells))
            {
                return true;
            }else
            {
                return false;
            }
        }

        private static Boolean CheckRow(List<Cell> cells)
        {
            List<int> rowValueXs = new List<int>();
            foreach (var cell in cells)
            {
                rowValueXs.Add(cell.Position.RowValueX);
            }
            rowValueXs.Sort();
            int winCount = 3;
            var count = rowValueXs.GroupBy(item => item).Where(item => item.Count() >= winCount).Sum(item=> item.Count());
            return count == winCount;
        }
        
        private static Boolean CheckColumn(List<Cell> cells)
        {
            List<int> columnValueYs = new List<int>();
            foreach (var cell in cells)
            {
                columnValueYs.Add(cell.Position.ColumnValueY);
            }
            columnValueYs.Sort();
            int winCount = 3;
            var count = columnValueYs.GroupBy(item => item).Where(item => item.Count() >= winCount).Sum(item=> item.Count());
            return count == winCount;
        }

        private static Boolean CheckDiagonal(List<Cell> cells)
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

            if (topLeftToBottomRightCount == 3 || bottomLeftToTopRightCount==3)
            {
                return true;
            }
            else
            {
                return false; 
            }
        }
    }
}