namespace SudokuSolver.Tests;

using SudokuSolver;
using Xunit;

public class ParsingTests
{
    /// <summary>Tests that the constructor throws an exception when given an invalid board.</summary>
    /// <param name="invalid">A string representation of an invalid Sudoku board.</param>
    [Theory]
    [InlineData("112345678900000000000000000000000000000000000000000000000000000000000000000000000")] // Duplicate 1 in first row
    [InlineData("123456789123000000000000000000000000000000000000000000000000000000000000000000000")] // Duplicate 1 in first col
    [InlineData("123456189000123000000000000000000000000000000000000000000000000000000000000000000")] // Duplicate 1 in top left box
    public void Constructor_Invalid_Board_ThrowsException(string invalid)
    {
        int [,] grid = ConsoleIO.parseBoard(invalid);
        Assert.Throws<ArgumentException>(() => new BitmaskBoard(grid));
    }

    /// <summary>Tests that the constructor throws an exception when given a board with invalid characters.</summary>
    /// <param name="invalid">A string representation of a Sudoku board with invalid characters.</
    [Theory]
    [InlineData("12345678X000000000000000000000000000000000000000000000000000000000000000000000000")]
    [InlineData("12345678000000000000000000000000000000000000000000000000000l000000000000000000000")]
    [InlineData("12345678000000000000000000000000000000000000000000000000000000000000000000000000j")]
    public void Char_In_Board_ThrowsException(string invalid)
    {
        Assert.Throws<ArgumentException>(() => ConsoleIO.parseBoard(invalid));
    }

    
    /// <summary>Tests that the constructor throws an exception when given a board with invalid length.</summary>
    /// <param name="invalid">A string representation of a Sudoku board with invalid length.</param>
    [Theory]
    [InlineData("1234567890000000000000000000000000000000000000000000000000000000000000")] // Too short
    [InlineData("1234567890000000000000000000000000000000000000000000000000000000000000000000000000000")] // Too long
    [InlineData("")] // Empty board
    public void Invalid_Length_Board_ThrowsException(string invalid) 
    {
        Assert.Throws<ArgumentException>(() => ConsoleIO.parseBoard(invalid));
    }
    
}
