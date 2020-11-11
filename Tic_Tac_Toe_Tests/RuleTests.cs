using Tic_Tac_Toe;
using Xunit;

namespace Tic_Tac_Toe_Tests
{
    public class RuleTests
    {
        private readonly Board _newBoard = new Board(3);
        private readonly TicTacToeRule _rule = new TicTacToeRule();

        [Fact]
        public void DetermineWin_ShouldReturnTrue_When3SameValueCellsOnTheSameRow()
        {
            _newBoard.UpdateBoard(new Location(1, 1), Piece.X);
            _newBoard.UpdateBoard(new Location(2, 1), Piece.O);
            _newBoard.UpdateBoard(new Location(1, 2), Piece.X);
            _newBoard.UpdateBoard(new Location(2, 2), Piece.O);
            _newBoard.UpdateBoard(new Location(1, 3), Piece.X);

            var result = _rule.DetermineWin(_newBoard, Piece.X);
            
            Assert.True(result);
        }

        [Fact]
        public void DetermineWin_ShouldReturnFalse_When2SameValueCellsOnTheSameRow()
        {
            _newBoard.UpdateBoard(new Location(1, 1), Piece.X);
            _newBoard.UpdateBoard(new Location(2, 1), Piece.O);
            _newBoard.UpdateBoard(new Location(1, 2), Piece.X);
            _newBoard.UpdateBoard(new Location(2, 2), Piece.O);
            _newBoard.UpdateBoard(new Location(1, 3), Piece.X);
        
            var result = _rule.DetermineWin(_newBoard, Piece.O);
            
            Assert.False(result);
        }
        
        [Fact]
        public void DetermineWin_ShouldReturnTrue_When3SameValueCellsOnTheSameColumn()
        {
            _newBoard.UpdateBoard(new Location(1, 3), Piece.X);
            _newBoard.UpdateBoard(new Location(2, 1), Piece.O);
            _newBoard.UpdateBoard(new Location(2, 3), Piece.X);
            _newBoard.UpdateBoard(new Location(2, 2), Piece.O);
            _newBoard.UpdateBoard(new Location(3, 3), Piece.X);
        
            var result = _rule.DetermineWin(_newBoard, Piece.X);
            
            Assert.True(result);
        }
        
        [Fact]
        public void DetermineWin_ShouldReturnFalse_When2SameValueCellsOnTheSameColumn()
        {
            _newBoard.UpdateBoard(new Location(1, 3), Piece.X);
            _newBoard.UpdateBoard(new Location(2, 1), Piece.O);
            _newBoard.UpdateBoard(new Location(2, 2), Piece.X);
            _newBoard.UpdateBoard(new Location(3, 1), Piece.O);
            _newBoard.UpdateBoard(new Location(3, 2), Piece.X);
        
            var result = _rule.DetermineWin(_newBoard, Piece.O);
            
            Assert.False(result);
        }
        
        [Fact]
        public void DetermineWin_ShouldReturnTrue_When3SameValueCellsOnTopLeftToBottomRightDiagonal()
        {
            _newBoard.UpdateBoard(new Location(1, 1), Piece.X);
            _newBoard.UpdateBoard(new Location(2, 1), Piece.O);
            _newBoard.UpdateBoard(new Location(2, 2), Piece.X);
            _newBoard.UpdateBoard(new Location(3, 1), Piece.O);
            _newBoard.UpdateBoard(new Location(3, 3), Piece.X);
        
            var result = _rule.DetermineWin(_newBoard, Piece.X);
            
            Assert.True(result);
        }
        
        [Fact]
        public void DetermineWin_ShouldReturnTrue_When3SameValueCellsOnBottomLeftToTopRightDiagonal()
        {
            _newBoard.UpdateBoard(new Location(3, 1), Piece.O);
            _newBoard.UpdateBoard(new Location(2, 1), Piece.X);
            _newBoard.UpdateBoard(new Location(2, 2), Piece.O);
            _newBoard.UpdateBoard(new Location(3, 2), Piece.X);
            _newBoard.UpdateBoard(new Location(1, 3), Piece.O);
        
            var result = _rule.DetermineWin(_newBoard, Piece.O);
            
            Assert.True(result);
        }
        
        [Fact]
        public void DetermineWin_ShouldReturnFalse_When3SameValueCellsAreNotOnTheSameLine()
        {
            _newBoard.UpdateBoard(new Location(1, 1), Piece.O);
            _newBoard.UpdateBoard(new Location(2, 1), Piece.X);
            _newBoard.UpdateBoard(new Location(2, 3), Piece.O);
            _newBoard.UpdateBoard(new Location(3, 3), Piece.X);
            _newBoard.UpdateBoard(new Location(3, 2), Piece.O);
        
            var result = _rule.DetermineWin(_newBoard, Piece.O);
            
            Assert.False(result);
        }
    }
}