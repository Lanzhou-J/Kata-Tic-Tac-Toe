using System;
namespace Tic_Tac_Toe
{
    public class PlayerInput
    {
        private string Ask(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }

        public string CollectPlayerInput(string playerName, string cellValue)
        {
            var instruction = $"{playerName} enter a coord x,y to place your {cellValue} or enter 'q' to give up: ";
            var input = Ask(instruction);
            return input;
        }

    }
}