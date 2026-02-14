public class BacktrackSolver : ISolver
{
  /// <summary>Solves the given Sudoku board using backtracking</summary>
  /// <param name="board">The board to be solved</param>
  /// <returns>True if the board was solved successfully, false otherwise</returns>
  /// <exception cref="ArgumentException">Thrown if the provided board does not implement IListCandidatesBoard</exception>
  public bool Solve(IBoard board) {
    if (board is not IListCandidatesBoard listBoard)
      throw new ArgumentException("BacktrackSolver requires an IListCandidatesBoard instace.");

    return SolveRecursive(listBoard, 0, 0);
  } 
  
  /// <summary>Recursively attempts to solve the board using backtracking</summary>
  /// <param name="board">The board to be solved</param>
  /// <param name="row">The current row being processed</param>
  /// <param name="col">The current column being processed</param>
  /// <returns>True if the board was solved successfully, false otherwise</returns>
  private bool SolveRecursive(IListCandidatesBoard board, int row, int col)
  {
    int nextRow = row, nextCol = col + 1;
    if (nextCol == 9) { nextRow++; nextCol = 0; }

    if (row >= 9) return board.IsSolved;

    if (board.GetCell(row, col) != 0)
      return SolveRecursive(board, nextRow, nextCol);

    foreach (int val in board.GetPossibleCandidates(row, col))
    {
      board.SetCell(row, col, val);
      if (SolveRecursive(board, nextRow, nextCol)) return true;
      board.ClearCell(row, col);
    }

    return false;
  }
}
