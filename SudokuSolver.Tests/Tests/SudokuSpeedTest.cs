namespace SudokuSolver.Tests.Perforemance;

using SudokuSolver;
using System.Linq; 
using Xunit;
using System.Diagnostics;

public class SudokuSpeedTest 
{
  /// <summary>Tests that the solver can solve a single puzzle in under 1 second.</summary>
  /// <param name="input">A string representation of a Sudoku puzzle.</param>
  /// <returns>True if the puzzle is solved in under 1 second, false otherwise</returns>
  private bool Solved_Under_1_Second(string input)
  {
    int [,] grid = ConsoleIO.parseBoard(input);
    var board = new BitmaskBoard(grid); 
    ISolver solver = SolverFactory.CreateSolver(board);

    Stopwatch sw = new Stopwatch();
    sw.Start();
    solver.Solve(board);
    sw.Stop();
    
    return sw.Elapsed.TotalSeconds < 1;
  }

  
  /// <summary>Tests that the solver can solve 100 puzzles in under 1 second each.</summary>
  [Fact]
  public void Sudoku_Solve_Time()
  {
     var puzzles = File.ReadLines("Source_Files/100_puzzles.txt")
       .Where(line => !string.IsNullOrWhiteSpace(line))
       .Select(line => Solved_Under_1_Second(line))
       .ToArray();

     Assert.All(puzzles, result => Assert.True(result));
  }
}
