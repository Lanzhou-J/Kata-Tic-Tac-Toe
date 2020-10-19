using Tic_Tac_Toe;
using Xunit;

namespace Tic_Tac_Toe_Tests
{
    public class GameTests
    {
        private const string QuitResponse = "q";
        private TicTacToeRule _rule = new TicTacToeRule();

        [Fact]
            public void PlayShould_ChangeGameStateQuit_WhenUserInputQ()
            {
                IInputOutput iio = new TestResponder(new[]{QuitResponse}); 
                Game newGame = new Game(iio, _rule);
                newGame.Play();
                Assert.Equal(GameState.Quit,newGame.GameState);
            }
            
            [Fact]
            public void PlayShould_ReturnGameStateQuit_WhenUserInputListEndWithQ()
            {
                IInputOutput iio = new TestResponder(new[]{"1,1","1,2","1,3",QuitResponse}); 
                Game newGame = new Game(iio, _rule);
                newGame.Play();
                Assert.Equal(GameState.Quit,newGame.GameState);
            }

    }
}