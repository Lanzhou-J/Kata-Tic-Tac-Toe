using System.Collections.Generic;
using Xunit;
using Tic_Tac_Toe;

namespace Tic_Tac_Toe_Tests
{
    public class BoardTests
    {

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

        [Fact]
        public void LocationCellIsEmptyShould_ReturnTrue_WhenTheLocationCellIsEmpty()
        {
            int boardSize = 3;
            Board newBoard = new Board(boardSize);
            Location newLocation = new Location(3,1);
            Assert.True(newBoard.LocationCellIsEmpty(newLocation));
        }
        
        [Fact]
        public void LocationCellIsEmptyShould_ReturnFalse_WhenTheLocationCellIsNotEmpty()
        {
            int boardSize = 3;
            Board newBoard = new Board(boardSize);
            Location newLocation = new Location(3,1);
            newBoard.UpdateBoard(newLocation, CellValue.X);
            Assert.False(newBoard.LocationCellIsEmpty(newLocation));
        }

        [Fact]
        public void UpdateBoard_WhenInputIsXAndValidCoord_ShouldUpdateBoard()
        {
            int boardSize = 3;
            Board newBoard = new Board(boardSize);
            Location newLocation = new Location(3,1);
            newBoard.UpdateBoard(newLocation, CellValue.X);

            List<CellValue> cellValues = new List<CellValue> {CellValue.Empty, CellValue.Empty, CellValue.Empty, CellValue.Empty, CellValue.Empty, CellValue.Empty, CellValue.X, CellValue.Empty, CellValue.Empty};
            int index = 0;
            foreach (var cell in newBoard.Cells)
            {
                Assert.Equal(cellValues[index], cell.Value);
                index++;
            }
            
            
        }
    }
}