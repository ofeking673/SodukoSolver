public class Solver {
  
  private const int SIZE = 9;

  public bool Solve(IBoard board) {
    for (int row = 0; row < SIZE; row++) 
    {
      for (int col = 0; col < SIZE; col++) 
      {
        if (board.GetCell(row, col) == 0) 
        {
          List<int> candidates = board.GetPossibleCandidates(row, col);

          foreach (int val in candidates)
          {
            board.SetCell(row, col, val);

            if (Solve(board)) {
              return true;
            }

            board.ClearCell(row, col); // Backtrack
          }

          return false;
        }
      }
    } 

    return true;
  }

}
