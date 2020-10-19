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
            _newBoard.UpdateBoard(new Location(1, 1), CellValue.X);
            _newBoard.UpdateBoard(new Location(2, 1), CellValue.O);
            _newBoard.UpdateBoard(new Location(1, 2), CellValue.X);
            _newBoard.UpdateBoard(new Location(2, 2), CellValue.O);
            _newBoard.UpdateBoard(new Location(1, 3), CellValue.X);

            var result = Rule.DetermineWin(_newBoard, CellValue.X);
            
            Assert.True(result);
        }

        [Fact]
        public void DetermineWin_ShouldReturnFalse_When2SameValueCellsOnTheSameRow()
        {
            _newBoard.UpdateBoard(new Location(1, 1), CellValue.X);
            _newBoard.UpdateBoard(new Location(2, 1), CellValue.O);
            _newBoard.UpdateBoard(new Location(1, 2), CellValue.X);
            _newBoard.UpdateBoard(new Location(2, 2), CellValue.O);
            _newBoard.UpdateBoard(new Location(1, 3), CellValue.X);
        
            var result = Rule.DetermineWin(_newBoard, CellValue.O);
            
            Assert.False(result);
        }
        
        [Fact]
        public void DetermineWin_ShouldReturnTrue_When3SameValueCellsOnTheSameColumn()
        {
            _newBoard.UpdateBoard(new Location(1, 3), CellValue.X);
            _newBoard.UpdateBoard(new Location(2, 1), CellValue.O);
            _newBoard.UpdateBoard(new Location(2, 3), CellValue.X);
            _newBoard.UpdateBoard(new Location(2, 2), CellValue.O);
            _newBoard.UpdateBoard(new Location(3, 3), CellValue.X);
        
            var result = Rule.DetermineWin(_newBoard, CellValue.X);
            
            Assert.True(result);
        }
        
        [Fact]
        public void DetermineWin_ShouldReturnFalse_When2SameValueCellsOnTheSameColumn()
        {
            _newBoard.UpdateBoard(new Location(1, 3), CellValue.X);
            _newBoard.UpdateBoard(new Location(2, 1), CellValue.O);
            _newBoard.UpdateBoard(new Location(2, 2), CellValue.X);
            _newBoard.UpdateBoard(new Location(3, 1), CellValue.O);
            _newBoard.UpdateBoard(new Location(3, 2), CellValue.X);
        
            var result = Rule.DetermineWin(_newBoard, CellValue.O);
            
            Assert.False(result);
        }
        
        [Fact]
        public void DetermineWin_ShouldReturnTrue_When3SameValueCellsOnTopLeftToBottomRightDiagonal()
        {
            _newBoard.UpdateBoard(new Location(1, 1), CellValue.X);
            _newBoard.UpdateBoard(new Location(2, 1), CellValue.O);
            _newBoard.UpdateBoard(new Location(2, 2), CellValue.X);
            _newBoard.UpdateBoard(new Location(3, 1), CellValue.O);
            _newBoard.UpdateBoard(new Location(3, 3), CellValue.X);
        
            var result = Rule.DetermineWin(_newBoard, CellValue.X);
            
            Assert.True(result);
        }
        
        [Fact]
        public void DetermineWin_ShouldReturnTrue_When3SameValueCellsOnBottomLeftToTopRightDiagonal()
        {
            _newBoard.UpdateBoard(new Location(3, 1), CellValue.O);
            _newBoard.UpdateBoard(new Location(2, 1), CellValue.X);
            _newBoard.UpdateBoard(new Location(2, 2), CellValue.O);
            _newBoard.UpdateBoard(new Location(3, 2), CellValue.X);
            _newBoard.UpdateBoard(new Location(1, 3), CellValue.O);
        
            var result = Rule.DetermineWin(_newBoard, CellValue.O);
            
            Assert.True(result);
        }
        
        [Fact]
        public void DetermineWin_ShouldReturnFalse_When3SameValueCellsAreNotOnTheSameLine()
        {
            _newBoard.UpdateBoard(new Location(1, 1), CellValue.O);
            _newBoard.UpdateBoard(new Location(2, 1), CellValue.X);
            _newBoard.UpdateBoard(new Location(2, 3), CellValue.O);
            _newBoard.UpdateBoard(new Location(3, 3), CellValue.X);
            _newBoard.UpdateBoard(new Location(3, 2), CellValue.O);
        
            var result = Rule.DetermineWin(_newBoard, CellValue.O);
            
            Assert.False(result);
        }
    }
}