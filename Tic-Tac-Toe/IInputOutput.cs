namespace Tic_Tac_Toe
{
    public interface IInputOutput
    {
        public string Ask(string question);

        void Output(string message);

        void PrintBoard(Board board);
    }
}