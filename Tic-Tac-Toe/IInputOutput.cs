using System;

namespace Tic_Tac_Toe
{
    public interface IInputOutput
    {
        public string Ask(string question);

        public string CollectPlayerInput(Player player);

        void Output(string message);

        void Output(Board board);
    }
}