namespace Tic_Tac_Toe
{
    public class Player
    {
        public CellValue CellValue { get; set; }
        public string Name { get; set; }

        public Player(CellValue cellValue, string name)
        {
            CellValue = cellValue;
            Name = name;
        }
    }
    
}