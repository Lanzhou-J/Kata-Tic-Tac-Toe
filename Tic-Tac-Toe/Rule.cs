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
            List<Cell> sameValueCells = gameBoard.Cells.FindAll(x => x.Value.Equals(cellValue));
            if (CheckRow(gameBoard, sameValueCells))
            {
                return true;
            }else if(CheckColumn(gameBoard,sameValueCells))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static Boolean CheckRow(Board gameBoard, List<Cell> cells)
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
        
        private static Boolean CheckColumn(Board gameBoard, List<Cell> cells)
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

        private static Boolean CheckDiagonal()
        {
            //Sort cell items in sameValueCells based on RowValueX.
            //select cell items in sameValueCells that are both:
                //1. X value 
            return false;
        }
    }
}