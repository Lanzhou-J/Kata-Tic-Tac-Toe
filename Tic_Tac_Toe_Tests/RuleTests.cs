using Tic_Tac_Toe;
using Xunit;

namespace Tic_Tac_Toe_Tests
{
    public class RuleTests
    {
        // Rule class -> test it
        //DetermineWinner() should return a boolean.
        //When 3 cells on the same row has same value -> return true.
        //When 3 cells on the same column has same value -> return true.
        //When 3 cells on the same diagonal has same value -> return true.
        //When only 2 same value cells on the same row -> return false.
        //When 3 same value cells are not on the same line -> return false.

        Board _newBoard = new Board(3);

        [Fact]
        public void DetermineWin_ShouldReturnTrue_When3SameValueCellsOnTheSameRow()
        {
            var board1 = _newBoard.UpdateBoard(new Coord(1, 1), CellValue.X);
            var board2 = board1.UpdateBoard(new Coord(2, 1), CellValue.O);
            var board3 = board2.UpdateBoard(new Coord(1, 2), CellValue.X);
            var board4 = board3.UpdateBoard(new Coord(2, 2), CellValue.O);
            var board5 = board4.UpdateBoard(new Coord(1, 3), CellValue.X);

            var result = Rule.DetermineWin(board5, CellValue.X);
            
            Assert.True(result);
        }

        [Fact]
        public void DetermineWin_ShouldReturnFalse_When2SameValueCellsOnTheSameRow()
        {
            var board1 = _newBoard.UpdateBoard(new Coord(1, 1), CellValue.X);
            var board2 = board1.UpdateBoard(new Coord(2, 1), CellValue.O);
            var board3 = board2.UpdateBoard(new Coord(1, 2), CellValue.X);
            var board4 = board3.UpdateBoard(new Coord(2, 2), CellValue.O);
            var board5 = board4.UpdateBoard(new Coord(1, 3), CellValue.X);
        
            var result = Rule.DetermineWin(board5, CellValue.O);
            
            Assert.False(result);
        }
        
        [Fact]
        public void DetermineWin_ShouldReturnTrue_When3SameValueCellsOnTheSameColumn()
        {
            var board1 = _newBoard.UpdateBoard(new Coord(1, 3), CellValue.X);
            var board2 = board1.UpdateBoard(new Coord(2, 1), CellValue.O);
            var board3 = board2.UpdateBoard(new Coord(2, 3), CellValue.X);
            var board4 = board3.UpdateBoard(new Coord(2, 2), CellValue.O);
            var board5 = board4.UpdateBoard(new Coord(3, 3), CellValue.X);
        
            var result = Rule.DetermineWin(board5, CellValue.X);
            
            Assert.True(result);
        }
        
        [Fact]
        public void DetermineWin_ShouldReturnFalse_When2SameValueCellsOnTheSameColumn()
        {
            var board1 = _newBoard.UpdateBoard(new Coord(1, 3), CellValue.X);
            var board2 = board1.UpdateBoard(new Coord(2, 1), CellValue.O);
            var board3 = board2.UpdateBoard(new Coord(2, 2), CellValue.X);
            var board4 = board3.UpdateBoard(new Coord(3, 1), CellValue.O);
            var board5 = board4.UpdateBoard(new Coord(3, 2), CellValue.X);
        
            var result = Rule.DetermineWin(board5, CellValue.O);
            
            Assert.False(result);
        }
        
        [Fact]
        public void DetermineWin_ShouldReturnTrue_When3SameValueCellsOnTopLeftToBottomRightDiagonal()
        {
            var board1 = _newBoard.UpdateBoard(new Coord(1, 1), CellValue.X);
            var board2 = board1.UpdateBoard(new Coord(2, 1), CellValue.O);
            var board3 = board2.UpdateBoard(new Coord(2, 2), CellValue.X);
            var board4 = board3.UpdateBoard(new Coord(3, 1), CellValue.O);
            var board5 = board4.UpdateBoard(new Coord(3, 3), CellValue.X);
        
            var result = Rule.DetermineWin(board5, CellValue.X);
            
            Assert.True(result);
        }
        
        [Fact]
        public void DetermineWin_ShouldReturnTrue_When3SameValueCellsOnBottomLeftToTopRightDiagonal()
        {
            var board1 = _newBoard.UpdateBoard(new Coord(3, 1), CellValue.O);
            var board2 = board1.UpdateBoard(new Coord(2, 1), CellValue.X);
            var board3 = board2.UpdateBoard(new Coord(2, 2), CellValue.O);
            var board4 = board3.UpdateBoard(new Coord(3, 2), CellValue.X);
            var board5 = board4.UpdateBoard(new Coord(1, 3), CellValue.O);
        
            var result = Rule.DetermineWin(board5, CellValue.O);
            
            Assert.True(result);
        }
        
        [Fact]
        public void DetermineWin_ShouldReturnFalse_When3SameValueCellsAreNotOnTheSameLine()
        {
            var board1 = _newBoard.UpdateBoard(new Coord(1, 1), CellValue.O);
            var board2 = board1.UpdateBoard(new Coord(2, 1), CellValue.X);
            var board3 = board2.UpdateBoard(new Coord(2, 3), CellValue.O);
            var board4 = board3.UpdateBoard(new Coord(3, 3), CellValue.X);
            var board5 = board4.UpdateBoard(new Coord(3, 2), CellValue.O);
        
            var result = Rule.DetermineWin(board5, CellValue.O);
            
            Assert.False(result);
        }
    }
}