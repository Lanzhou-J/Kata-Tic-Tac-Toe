using Tic_Tac_Toe;
using Xunit;

namespace Tic_Tac_Toe_Tests
{
    public class GameTests
    {
        private const string QuitResponse = "q";
        private readonly TicTacToeRule _rule = new TicTacToeRule();
        private readonly Player _player1 = new Player(CellValue.X, "Player 1");
        private readonly Player _player2 = new Player(CellValue.O, "Player 2");

        [Fact]
            public void PlayShould_ChangeGameStateToQuit_WhenUserInputQ()
            {
                IInputOutput iio = new TestResponder(new[]{QuitResponse}); 
                Game newGame = new Game(iio, _rule, _player1, _player2);
                newGame.Play();
                Assert.Equal(GameState.Quit,newGame.GameState);
            }
            
            [Fact]
            public void PlayShould_ChangeGameStateToQuit_WhenUserInputListEndWithQ()
            {
                IInputOutput iio = new TestResponder(new[]{"1,1","1,2","1,3",QuitResponse}); 
                Game newGame = new Game(iio, _rule,_player1, _player2);
                newGame.Play();
                Assert.Equal(GameState.Quit,newGame.GameState);
            }
            
            [Fact]
            public void PlayShould_DeterminePlayer1IsWinner_WhenPlayer1InputLocationOnTheSameColumn()
            {
                IInputOutput iio = new TestResponder(new[]{"1,1","2,2","1,3","3,3","1,2",QuitResponse}); 
                Game newGame = new Game(iio, _rule, _player1, _player2);
                newGame.Play();
                Assert.True(_player1.IsWinner);
            }
            
            [Fact]
            public void PlayShould_DeterminePlayer2IsWinner_WhenPlayer2InputLocationOnTheSameDiagonal()
            {
                IInputOutput iio = new TestResponder(new[]{"2,1","2,2","1,3","3,3","1,2","1,1"}); 
                Game newGame = new Game(iio, _rule, _player1, _player2);
                newGame.Play();
                Assert.True(_player2.IsWinner);
            }
            
            [Fact]
            public void PlayShould_DeterminePlayer2IsWinner_WhenPlayer2InputLocationOnTheSameRow()
            {
                IInputOutput iio = new TestResponder(new[]{"3,1","2,2","1,3","2,3","1,2","2,1"}); 
                Game newGame = new Game(iio, _rule, _player1, _player2);
                newGame.Play();
                Assert.True(_player2.IsWinner);
            }
    }
}