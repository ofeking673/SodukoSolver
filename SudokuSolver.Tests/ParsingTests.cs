namespace SudokuSolver.Tests;

using SudokuSolver;
using Xunit;

public class ParsingTests
{
    [Theory]
    [InlineData("112345678900000000000000000000000000000000000000000000000000000000000000000000000")] // Duplicate 1 in first row
    [InlineData("123456789123000000000000000000000000000000000000000000000000000000000000000000000")] // Duplicate 1 in first col
    [InlineData("123456189000123000000000000000000000000000000000000000000000000000000000000000000")] // Duplicate 1 in top left box
    public void Constructor_InvalidBoard_ThrowsException(string invalid)
    {
        int [,] grid = ConsoleIO.parseBoard(invalid);
        Assert.Throws<ArgumentException>(() => new Board(grid));
    }


    
}
