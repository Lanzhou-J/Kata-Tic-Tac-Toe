using System;
namespace Tic_Tac_Toe
{
    public class Player
    {
        public CellValue CellValue { get; private set; }
        public string Name { get; private set; }

        public bool IsCurrentPlayer { get; }
        
        private readonly IInputOutput _iio;

        public Player(CellValue cellValue, string name, IInputOutput iio)
        {
            CellValue = cellValue;
            Name = name;
            _iio = iio;
            IsCurrentPlayer = false;
        }
        
        public string CollectPlayerInput()
        {
            var instruction = $"{Name} enter a coord x,y to place your {CellValue} or enter 'q' to give up: ";
            var input = _iio.Ask(instruction);
            return input;
        }
    }
    
}