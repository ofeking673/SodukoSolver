namespace SudokuSolver.Tests.Perforemance;

using SudokuSolver;
using System.Linq; 
using Xunit;
using System.Diagnostics;

public class SudokuSpeedTest 
{

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
