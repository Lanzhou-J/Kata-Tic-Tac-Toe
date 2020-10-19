using System;

namespace Tic_Tac_Toe
{
    public interface IRule
    {
        public Boolean DetermineWin(Board gameBoard, CellValue cellValue);
    }
}