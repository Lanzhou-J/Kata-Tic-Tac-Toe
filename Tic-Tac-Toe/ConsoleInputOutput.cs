using System;

namespace Tic_Tac_Toe
{
    public class ConsoleInputOutput: IInputOutput
    {
        public string Ask(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
        
        public void Output(string message)
        {
            Console.WriteLine(message);
        }
    }
}