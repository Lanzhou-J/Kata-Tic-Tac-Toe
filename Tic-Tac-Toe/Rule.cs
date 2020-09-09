using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Tic_Tac_Toe
{
    public static class Rule
    {
        
        public static Boolean DetermineWin(Board gameBoard, CellValue cellValue)
        {
            if (CheckRow(gameBoard, cellValue))
            {
                return true;
            }else if(CheckColumn(gameBoard,cellValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static Boolean CheckRow(Board gameBoard, CellValue cellValue)
        {
            List<Cell> parts = gameBoard.Cells.FindAll(x => x.Value.Equals(cellValue));

            List<int> rowValueXs = new List<int>();
            foreach (var cell in parts)
            {
                rowValueXs.Add(cell.Position.RowValueX);
            }
            rowValueXs.Sort();
            int winCount = 3;
            var count = rowValueXs.GroupBy(item => item).Where(item => item.Count() >= winCount).Sum(item=> item.Count());
            return count == winCount;
        }
        
        private static Boolean CheckColumn(Board gameBoard, CellValue cellValue)
        {
            List<Cell> parts = gameBoard.Cells.FindAll(x => x.Value.Equals(cellValue));

            List<int> columnValueYs = new List<int>();
            foreach (var cell in parts)
            {
                columnValueYs.Add(cell.Position.ColumnValueY);
            }
            columnValueYs.Sort();
            int winCount = 3;
            var count = columnValueYs.GroupBy(item => item).Where(item => item.Count() >= winCount).Sum(item=> item.Count());
            return count == winCount;
        }
    }
}