using System.Collections.Generic;
using Tic_Tac_Toe;

namespace Tic_Tac_Toe_Tests
{
    public class TestResponder:IInputOutput
    {
        private readonly Queue <string>_testResponses = new Queue<string>();
        public TestResponder(IEnumerable<string> testResponse)
        {
            foreach (var response in testResponse)
            {
                _testResponses.Enqueue(response);
            }
        }

        public string Ask(string question)
        {
            return _testResponses.Dequeue();
        }

        public string CollectPlayerInput(Player player)
        {
            var instruction = $"{player.Name} enter a coord x,y to place your {player.CellValue} or enter 'q' to give up: ";
            var input = Ask(instruction);
            return input;
        }

        public void Output(string message)
        {
        }

        public void Output(Board board)
        {
        }
    }
}