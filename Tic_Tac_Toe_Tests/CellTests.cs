using Tic_Tac_Toe;
using Xunit;

namespace Tic_Tac_Toe_Tests
{
    public class CellTests
    {
        // When Value is X, DisplayCellValue should return "X".
        // When Value is O, DisplayCellValue should return "O".
        // When Value is Empty, DisplayCellValue should return ".".
        
        [Fact]
        public void DisplayCellValue_WhenCellValueIsX_ShouldReturnStringX()
        {
            Coord newCoord = new Coord(1,1);
            Cell newCell = new Cell(newCoord, CellValue.X);
            Assert.Equal("X", newCell.DisplayCellValue());
        }
        
        [Fact]
        public void DisplayCellValue_WhenCellValueIsO_ShouldReturnStringO()
        {
            Coord newCoord = new Coord(1,1);
            Cell newCell = new Cell(newCoord, CellValue.O);
            Assert.Equal("O", newCell.DisplayCellValue());
        }
        
        [Fact]
        public void DisplayCellValue_WhenCellValueIsEmpty_ShouldReturnStringDot()
        {
            Coord newCoord = new Coord(1,1);
            Cell newCell = new Cell(newCoord, CellValue.Empty);
            Assert.Equal(".", newCell.DisplayCellValue());
        }
    }
}