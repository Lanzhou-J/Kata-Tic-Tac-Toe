namespace Tic_Tac_Toe
{
    public class Player
    {
        public CellValue CellValue { get; }
        public string Name { get; }

        public bool IsWinner { get; set; }

        public Player(CellValue cellValue, string name)
        {
            CellValue = cellValue;
            Name = name;
            IsWinner = false;
        }
    }
    
}