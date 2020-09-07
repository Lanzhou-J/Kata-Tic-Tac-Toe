using Xunit;
using Tic_Tac_Toe;

namespace Tic_Tac_Toe_Tests
{
    public class BoardTests
    {
        
        // Add comments -> test planning
        // user input 1,3, -> update Board
        
        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void NewBoard_ShouldInstantiateCorrectNumberOfCells(int value)
        {
            Board newBoard = new Board(value);
            int correctNumber = value * value;
            Assert.Equal(correctNumber, newBoard.Cells.Count);
        }
        
        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void EachCellInNewBoardCells_ShouldHaveValidCoord(int value)
        {
            Board newBoard = new Board(value);
            foreach (var cell in newBoard.Cells)
            {
                Assert.IsType<Cell>(cell);
            }
        }
        
        [Theory]
        [InlineData(3,5)]
        [InlineData(4,7)]
        [InlineData(5,9)]
        public void CellInNewBoardCells_ShouldHaveCorrectCoordYValue(int size, int index)
        { 
            Board newBoard = new Board(size);
            int columnValue = (index+1) % size;
            if (columnValue == 0)
            {
                columnValue = size;
            }

            Assert.Equal(columnValue,newBoard.Cells[index].Position.ColumnValueY );
        }
        
        [Theory]
        [InlineData(3,5)]
        [InlineData(4,6)]
        [InlineData(5,10)]
        public void CellInNewBoardCells_ShouldHaveCorrectCoordXValue(int size, int index)
        { 
            Board newBoard = new Board(size);
            int rowValue;
            if ((index+1)%size == 0)
            {
                rowValue = (index + 1) / size;
            }
            else
            {
                rowValue =  (index + 1) / size + 1;
            }
            
            Assert.Equal(rowValue,newBoard.Cells[index].Position.RowValueX );
        }
    }
}