using Tic_Tac_Toe;
using Xunit;

namespace Tic_Tac_Toe_Tests
{
    public class CellTests
    {

        [Fact]
        public void DisplayCellValue_WhenCellValueIsX_ShouldReturnStringX()
        {
            Location newLocation = new Location(1,1);
            Cell newCell = new Cell(newLocation, CellValue.X);
            Assert.Equal("X", newCell.DisplayCellValue());
        }
        
        [Fact]
        public void DisplayCellValue_WhenCellValueIsO_ShouldReturnStringO()
        {
            Location newLocation = new Location(1,1);
            Cell newCell = new Cell(newLocation, CellValue.O);
            Assert.Equal("O", newCell.DisplayCellValue());
        }
        
        [Fact]
        public void DisplayCellValue_WhenCellValueIsEmpty_ShouldReturnStringDot()
        {
            Location newLocation = new Location(1,1);
            Cell newCell = new Cell(newLocation, CellValue.Empty);
            Assert.Equal(".", newCell.DisplayCellValue());
        }
    }
}