using Tic_Tac_Toe;
using Xunit;

namespace Tic_Tac_Toe_Tests
{
    public class RuleTests
    {
        private readonly Board _newBoard = new Board(3);

        [Fact]
        public void DetermineWin_ShouldReturnTrue_When3SameValueCellsOnTheSameRow()
        {
            var board1 = _newBoard.UpdateBoard(new Location(1, 1), CellValue.X);
            var board2 = board1.UpdateBoard(new Location(2, 1), CellValue.O);
            var board3 = board2.UpdateBoard(new Location(1, 2), CellValue.X);
            var board4 = board3.UpdateBoard(new Location(2, 2), CellValue.O);
            var board5 = board4.UpdateBoard(new Location(1, 3), CellValue.X);

            var result = Rule.DetermineWin(board5, CellValue.X);
            
            Assert.True(result);
        }

        [Fact]
        public void DetermineWin_ShouldReturnFalse_When2SameValueCellsOnTheSameRow()
        {
            var board1 = _newBoard.UpdateBoard(new Location(1, 1), CellValue.X);
            var board2 = board1.UpdateBoard(new Location(2, 1), CellValue.O);
            var board3 = board2.UpdateBoard(new Location(1, 2), CellValue.X);
            var board4 = board3.UpdateBoard(new Location(2, 2), CellValue.O);
            var board5 = board4.UpdateBoard(new Location(1, 3), CellValue.X);
        
            var result = Rule.DetermineWin(board5, CellValue.O);
            
            Assert.False(result);
        }
        
        [Fact]
        public void DetermineWin_ShouldReturnTrue_When3SameValueCellsOnTheSameColumn()
        {
            var board1 = _newBoard.UpdateBoard(new Location(1, 3), CellValue.X);
            var board2 = board1.UpdateBoard(new Location(2, 1), CellValue.O);
            var board3 = board2.UpdateBoard(new Location(2, 3), CellValue.X);
            var board4 = board3.UpdateBoard(new Location(2, 2), CellValue.O);
            var board5 = board4.UpdateBoard(new Location(3, 3), CellValue.X);
        
            var result = Rule.DetermineWin(board5, CellValue.X);
            
            Assert.True(result);
        }
        
        [Fact]
        public void DetermineWin_ShouldReturnFalse_When2SameValueCellsOnTheSameColumn()
        {
            var board1 = _newBoard.UpdateBoard(new Location(1, 3), CellValue.X);
            var board2 = board1.UpdateBoard(new Location(2, 1), CellValue.O);
            var board3 = board2.UpdateBoard(new Location(2, 2), CellValue.X);
            var board4 = board3.UpdateBoard(new Location(3, 1), CellValue.O);
            var board5 = board4.UpdateBoard(new Location(3, 2), CellValue.X);
        
            var result = Rule.DetermineWin(board5, CellValue.O);
            
            Assert.False(result);
        }
        
        [Fact]
        public void DetermineWin_ShouldReturnTrue_When3SameValueCellsOnTopLeftToBottomRightDiagonal()
        {
            var board1 = _newBoard.UpdateBoard(new Location(1, 1), CellValue.X);
            var board2 = board1.UpdateBoard(new Location(2, 1), CellValue.O);
            var board3 = board2.UpdateBoard(new Location(2, 2), CellValue.X);
            var board4 = board3.UpdateBoard(new Location(3, 1), CellValue.O);
            var board5 = board4.UpdateBoard(new Location(3, 3), CellValue.X);
        
            var result = Rule.DetermineWin(board5, CellValue.X);
            
            Assert.True(result);
        }
        
        [Fact]
        public void DetermineWin_ShouldReturnTrue_When3SameValueCellsOnBottomLeftToTopRightDiagonal()
        {
            var board1 = _newBoard.UpdateBoard(new Location(3, 1), CellValue.O);
            var board2 = board1.UpdateBoard(new Location(2, 1), CellValue.X);
            var board3 = board2.UpdateBoard(new Location(2, 2), CellValue.O);
            var board4 = board3.UpdateBoard(new Location(3, 2), CellValue.X);
            var board5 = board4.UpdateBoard(new Location(1, 3), CellValue.O);
        
            var result = Rule.DetermineWin(board5, CellValue.O);
            
            Assert.True(result);
        }
        
        [Fact]
        public void DetermineWin_ShouldReturnFalse_When3SameValueCellsAreNotOnTheSameLine()
        {
            var board1 = _newBoard.UpdateBoard(new Location(1, 1), CellValue.O);
            var board2 = board1.UpdateBoard(new Location(2, 1), CellValue.X);
            var board3 = board2.UpdateBoard(new Location(2, 3), CellValue.O);
            var board4 = board3.UpdateBoard(new Location(3, 3), CellValue.X);
            var board5 = board4.UpdateBoard(new Location(3, 2), CellValue.O);
        
            var result = Rule.DetermineWin(board5, CellValue.O);
            
            Assert.False(result);
        }
    }
}