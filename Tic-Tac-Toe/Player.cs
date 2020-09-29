using System;
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
        
        private string Ask(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }
        
        public string CollectPlayerInput()
        {
            var instruction = $"{Name} enter a coord x,y to place your {CellValue} or enter 'q' to give up: ";
            var input = Ask(instruction);
            return input;
        }
    }
    
}