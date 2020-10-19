using System;
namespace Tic_Tac_Toe
{
    public class Player
    {
        public CellValue CellValue { get; private set; }
        public string Name { get; private set; }

        // public bool IsCurrentPlayer { get; set; }

        public Player(CellValue cellValue, string name)
        {
            CellValue = cellValue;
            Name = name;
            // IsCurrentPlayer = false;
        }
    }
    
}