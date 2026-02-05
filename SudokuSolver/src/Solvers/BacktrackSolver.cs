public class BacktrackSolver : ISolver
{
  public bool Solve(IBoard board) {
    if (board is not IListCandidatesBoard listBoard)
      throw new ArgumentException("BacktrackSolver requires an IListCandidatesBoard instace.");

    return SolveRecursive(listBoard, 0, 0);
  } 

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
