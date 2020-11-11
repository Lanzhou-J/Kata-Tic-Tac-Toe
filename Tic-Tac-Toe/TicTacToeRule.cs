using System.Collections.Generic;
using System.Linq;

namespace Tic_Tac_Toe
{
    public class TicTacToeRule:IRule
    {
        private const int WinCount = 3;   
        public bool DetermineWin(Board gameBoard, Piece piece)
        {
            var samePieceCells = GetSamePieceCellsOnGameBoard(gameBoard, piece);
            return OnTheSameRow(samePieceCells)||OnTheSameColumn(samePieceCells)||OnTheSameDiagonal(samePieceCells);
        }

        private static List<Cell> GetSamePieceCellsOnGameBoard(Board gameBoard, Piece piece)
        {
            var samePieceCells = gameBoard.Cells.FindAll(x => x.Value.Equals(piece));
            return samePieceCells;
        }

        private static bool OnTheSameRow(IEnumerable<Cell> cells)
        {
            var rowValues = GetRowValuesOfSamePieceCells(cells);
            rowValues.Sort();
            
            return DetermineIfSameValueItemsCountIsEqualToWinCount(rowValues);
        }

        private static bool DetermineIfSameValueItemsCountIsEqualToWinCount(List<int> values)
        {
            var count = values.GroupBy(item => item).Where(item => item.Count() >= WinCount).Sum(item => item.Count());
            return count == WinCount;
        }

        private static List<int> GetRowValuesOfSamePieceCells(IEnumerable<Cell> cells)
        {
            var rowValues = cells.Select(cell => cell.Location.Row).ToList();
            return rowValues;
        }

        private static bool OnTheSameColumn(IEnumerable<Cell> cells)
        {
            var columnValues = GetColumnValues(cells);
            columnValues.Sort();
            return DetermineIfSameValueItemsCountIsEqualToWinCount(columnValues);
        }

        private static List<int> GetColumnValues(IEnumerable<Cell> cells)
        {
            var columnValues = cells.Select(cell => cell.Location.Column).ToList();
            return columnValues;
        }

        private static bool OnTheSameDiagonal(IEnumerable<Cell> cells)
        {
            var topLeftToBottomRightCount = 0;
            var bottomLeftToTopRightCount = 0;
            foreach (var cell in cells)
            {
                if (OnTopLeftToBottomRightDiagonal(cell))
                {
                    topLeftToBottomRightCount++;
                }
                if (OnBottomLeftToTopRightDiagonal(cell))
                {
                    bottomLeftToTopRightCount++;
                }
            }
            return topLeftToBottomRightCount == WinCount || bottomLeftToTopRightCount == WinCount;
        }

        private static bool OnBottomLeftToTopRightDiagonal(Cell cell)
        {
            return cell.Location.Column + cell.Location.Row == 4;
        }

        private static bool OnTopLeftToBottomRightDiagonal(Cell cell)
        {
            return cell.Location.Column == cell.Location.Row;
        }
    }
}